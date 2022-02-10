using UnityEngine;

public class Invader : MonoBehaviour
{
    [SerializeField] Sprite[] animationSprites;
    [SerializeField] float animationTime = 1f;
    
    public System.Action killed;
    SpriteRenderer _spriteRenderer;
    int _animationFrame;

    InGameMenu menu;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        menu = FindObjectOfType<InGameMenu>();
    }
    void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), animationTime, animationTime);
    }

    void AnimateSprite()
    {
        _animationFrame++;

        if(_animationFrame >= animationSprites.Length)
        {
            _animationFrame = 0;
        }

        _spriteRenderer.sprite = this.animationSprites[_animationFrame];
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            killed.Invoke();
            gameObject.SetActive(false);
            menu.UpdateScore(1);
        }
    }

}
