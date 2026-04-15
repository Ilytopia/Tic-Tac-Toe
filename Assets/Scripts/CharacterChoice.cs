using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class CharacterChoice : MonoBehaviour
{
    private Player _player1;
    private Player _player2;
    
    private InputAction _clickAction;
    private Camera _camera;
    
    private List<ChoosableCharacter> _choosableCharacters = new List<ChoosableCharacter>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<Player>();
        _player2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Player>();
        
        _player2.enabled = false;
        
        _clickAction = InputSystem.actions.FindAction("Attack");
        _camera = Camera.main;

        foreach (ChoosableCharacter choosable_character in FindObjectsByType<ChoosableCharacter>(FindObjectsSortMode.None))
        {
            _choosableCharacters.Add(choosable_character);
        }
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

        if (!hit)
        {
            // Debug.Log("No Hit");
            return;
        }

        foreach (ChoosableCharacter choosable_character in _choosableCharacters)
        {
            if (choosable_character.gameObject == hit.collider.gameObject)
            {
                if (_player1.enabled)
                {
                    _player1.SetSprite(choosable_character.GetSpriteRenderer().sprite);
                }
                else
                {
                    _player2.SetSprite(choosable_character.GetSpriteRenderer().sprite);
                }
            }
        }
    }

    public void PreviousStep()
    {
        if (_player2.enabled)
        {
            _player2.enabled = false;
            _player1.enabled = true;
        }
        else
        {
            Destroy(_player1.gameObject);
            Destroy(_player2.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    public void NextStep()
    {
        if (_player1.enabled)
        {
            _player1.enabled = false;
            _player2.enabled = true;
        }
        else
        {
            _player1.enabled = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
