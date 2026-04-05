using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameGridDetections : MonoBehaviour
{
    private GameplayManager _gameplayManager;

    private InputAction _clickAction;
    private bool _clickWasPressed;
    
    private Collider2D _collider2D;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _gameplayManager = FindAnyObjectByType<GameplayManager>();
        _clickAction = InputSystem.actions.FindAction("Attack");

        _collider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _clickWasPressed = _clickAction.WasPressedThisFrame();
        
        if (_clickWasPressed)
        {
            CheckIfInteractWithBox();
        }
    }

    private void CheckIfInteractWithBox()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()), Vector3.forward);
        
        if (hit.collider == _collider2D)
        {
            _gameplayManager.ChangeTurn();
        }
    }
}
