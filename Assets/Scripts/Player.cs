using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private InputAction _clickAction;
    private Camera _camera;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
        _clickAction = InputSystem.actions.FindAction("Attack");
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (_clickAction.WasPressedThisFrame())
        {
            ChooseCharacter();
        }
    }

    private void ChooseCharacter()
    {
        RaycastHit2D hit = Physics2D.Raycast(_camera.ScreenToWorldPoint(Mouse.current.position.ReadValue()), Vector3.forward);

        if (hit.collider.gameObject.CompareTag("CharacterOption"))
        {
            
        }
    }

    public SpriteRenderer GetSpriteRenderer()
    {
        return _spriteRenderer;
    }
}
