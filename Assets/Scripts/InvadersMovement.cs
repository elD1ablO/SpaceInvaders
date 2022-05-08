using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvadersMovement : MonoBehaviour
{
    InGameMenu menu;

    [SerializeField] Invader[] prefabs;
    [SerializeField] Projectile missilePrefab;

    [SerializeField] AnimationCurve speed;    

    [SerializeField] float missileAttackRate = 1f;
    [SerializeField] int rows = 5;
    [SerializeField] int columns = 5;
    
    
    public int invadersKilled { get; private set; }    
    public int totalInvaders => rows * columns;
    public int invadersAlive => totalInvaders - invadersKilled;
    public float percentKilled => (float)invadersKilled / (float)totalInvaders;

    float _spacing = 0.8f;
    Vector3 _direction = Vector2.right;
    float _edgeBorder = 0.5f;

    private void Awake()
    {
        menu = FindObjectOfType<InGameMenu>();

        for (int row = 0; row < rows; row++)
        {
            float width = _spacing * (columns - 1);
            float height = _spacing * (rows - 1);

            Vector2 offset = new Vector2(-width / 2, -height / 2);
            Vector3 rowPosition = new Vector3(offset.x, offset.y + (row * _spacing), 0f);
            
            for (int col = 0; col < columns; col++)
            {
                Invader invader = Instantiate(prefabs[row], transform);
                invader.killed += InvaderKilled;
                Vector3 position = rowPosition;
                position.x += col * _spacing;
                invader.transform.localPosition = position;
            }
        }
    }

    void Start()
    {
        InvokeRepeating(nameof(MissileAttack),missileAttackRate, missileAttackRate);
    }

    void Update()
    {
        transform.position += _direction * speed.Evaluate(percentKilled) * Time.deltaTime;

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);
        
        foreach(Transform invader in transform)
        {
            if (!invader.gameObject.activeInHierarchy)
            {
                continue;
            }

            if(_direction == Vector3.right && invader.position.x >= (rightEdge.x - _edgeBorder))
            {
                MoveDown();
            }
            else if (_direction == Vector3.left && invader.position.x <= (leftEdge.x + _edgeBorder))
            {
                MoveDown();
            }
           
        }
    }

    void MoveDown()
    {
        _direction.x *= -1f;

        Vector3 position = transform.position;
        position.y -= _spacing;
        transform.position = position;
    }

    void MissileAttack()
    {
        foreach (Transform invader in transform)
        {
            if (!invader.gameObject.activeInHierarchy)
            {
                continue;
            }

            if (Random.value < (1f / (float)invadersAlive))
            {
                Instantiate(missilePrefab,invader.position, Quaternion.identity);
                break;
            }
        }
    }
    void InvaderKilled()
    {
        invadersKilled++;

        if (invadersKilled == totalInvaders)
        {
            menu.GameOver();
        }
    }
}
