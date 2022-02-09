using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvadersMovement : MonoBehaviour
{
    [SerializeField] Invader[] prefabs;
    [SerializeField] int rows = 5;
    [SerializeField] int columns = 5;
    [SerializeField] float speed = 0.01f;
    float _spacing = 0.8f;
    Vector3 _direction = Vector2.right;
    private void Awake()
    {
        for (int row = 0; row < rows; row++)
        {
            float width = _spacing * (columns - 1);
            float height = _spacing * (rows - 1);

            Vector2 offset = new Vector2(-width / 2, -height / 2);
            Vector3 rowPosition = new Vector3(offset.x, offset.y + (row * _spacing), 0f);
            
            for (int col = 0; col < columns; col++)
            {
                Invader invader = Instantiate(prefabs[row], transform);
                Vector3 position = rowPosition;
                position.x += col * _spacing;
                invader.transform.localPosition = position;
            }
        }
    }

    void Update()
    {
        transform.position += _direction * speed * Time.deltaTime;

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);
        
        foreach(Transform invader in transform)
        {
            if (!invader.gameObject.activeInHierarchy)
            {
                continue;
            }

            if(_direction == Vector3.right && invader.position.x >= (rightEdge.x - 0.3f))
            {
                MoveDown();
            }
            else if (_direction == Vector3.left && invader.position.x <= (leftEdge.x + 0.3f))
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
}
