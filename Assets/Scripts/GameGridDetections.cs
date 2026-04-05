using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameGridDetections : MonoBehaviour
{
    private GameplayManager _gameplayManager;

    private InputAction _clickAction;
    private bool _clickWasPressed;
    
    private Collider2D _collider2D;
    private Camera _camera;

    private bool _alreadyFull;
    private int _playerIndex;
    private SpriteRenderer _renderer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _gameplayManager = FindAnyObjectByType<GameplayManager>();
        _clickAction = InputSystem.actions.FindAction("Attack");

        _collider2D = GetComponent<Collider2D>();
        _camera = Camera.main;
        _renderer = GetComponentInChildren<SpriteRenderer>();
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
        RaycastHit2D hit = Physics2D.Raycast(_camera.ScreenToWorldPoint(Mouse.current.position.ReadValue()), Vector3.forward);
        
        if (hit.collider == _collider2D && !_alreadyFull)
        {
            ChangeVisual();
            _gameplayManager.ChangeTurn();
        }
    }

    private void ChangeVisual()
    {
        _alreadyFull = true;
        GameObject player = _gameplayManager.GetCurrentPlayer();
        
        _renderer.sprite = player.GetComponentInChildren<SpriteRenderer>().sprite;

        if (player.CompareTag("Player1"))
        {
            _playerIndex = 1;
        }
        else if (player.CompareTag("Player2"))
        {
            _playerIndex = 2;
        }
    }

    public bool GetIsFull()
    {
        return _alreadyFull;
    }

    public int GetPlayerIndex()
    {
        return _playerIndex;
    }
}
