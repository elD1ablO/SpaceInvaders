using UnityEngine;

public class Invader : MonoBehaviour
{
    [SerializeField] Sprite[] animationSprites;
    [SerializeField] float animationTime = 1f;

    SpriteRenderer _spriteRenderer;
    int _animationFrame;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
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
    
}
