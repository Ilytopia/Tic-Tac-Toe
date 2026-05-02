using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private bool _hasSprite;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public SpriteRenderer GetSpriteRenderer()
    {
        return _spriteRenderer;
    }

    public void SetSprite(Sprite sprite)
    {
        _spriteRenderer.sprite = sprite;
    }

    public bool HasSprite()
    {
        return _hasSprite;
    }

    public void SetHasSprite(bool has_sprite)
    {
        _hasSprite = has_sprite;
    }
}
