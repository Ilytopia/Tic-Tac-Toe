using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] private Player _player1;
    [SerializeField] private Player _player2;

    //private int _currentRound = 1;

    [SerializeField] private Player _currentPlayer;
    private Random  _random =  new Random();

    [SerializeField] private GameGridDetections[] _gameButtons;
    
    [SerializeField] private TMP_Text _currentPlayerRoundText;
    
    private GameManager _gameManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<Player>();
        _player2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Player>();

        if (_player1 == null || _player2 == null)
        {
            throw new NotImplementedException();
        }
        
        // _gameButtons = FindObjectsByType<GameGridDetections>(FindObjectsInactive.Exclude, FindObjectsSortMode.InstanceID);

        if (_gameButtons.Length != 9)
        {
            throw new NotImplementedException();
        }

        switch (_random.Next(1, 3))
        {
            case 1:
            {
                _currentPlayer = _player1;
                break;
            }
            case 2:
            {
                _currentPlayer = _player2;
                break;
            }
            default:
            {
                throw new NotImplementedException();
            }
        }

        _currentPlayerRoundText.text = _currentPlayer.gameObject.name;
        
        _gameManager = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeTurn()
    {
        CheckWinningCondition();
        
        if (_currentPlayer == _player1)
        {
            _currentPlayer = _player2;
        }
        else
        {
            _currentPlayer = _player1;
        }
        
        _currentPlayerRoundText.text = _currentPlayer.gameObject.name;
    }

    // WARNING the array is in reverse order so 0 is the 9th box and 8 is the 1rst box
    private void CheckWinningCondition()
    {
        bool is_full = true;
        foreach (GameGridDetections game_button in _gameButtons)
        {
            if (!game_button.GetIsFull())
            {
                is_full = false;
            }
        }

        if (is_full)
        {
            EndGame();
            return;
        }

        int player_checking;
        bool winning_condition;
        
        // Check Row
        // Last row
        player_checking = 0;
        winning_condition = true;
        for (int index = 0; index < 3; index++)
        {
            if (_gameButtons[index].GetPlayerIndex() == 0)
            {
                winning_condition = false;
                break;
            }
            
            if (player_checking == 0)
            {
                player_checking = _gameButtons[index].GetPlayerIndex();
            }
            else if (player_checking != _gameButtons[index].GetPlayerIndex())
            {
                winning_condition = false;
                break;
            }
        }

        if (winning_condition)
        {
            EndGame();
            return;
        }
        
        // Middle row
        player_checking = 0;
        winning_condition = true;
        for (int index = 3; index < 6; index++)
        {
            if (_gameButtons[index].GetPlayerIndex() == 0)
            {
                winning_condition = false;
                break;
            }
            
            if (player_checking == 0)
            {
                player_checking = _gameButtons[index].GetPlayerIndex();
            }
            else if (player_checking != _gameButtons[index].GetPlayerIndex())
            {
                winning_condition = false;
                break;
            }
        }

        if (winning_condition)
        {
            EndGame();
            return;
        }
        
        // Top row
        player_checking = 0;
        winning_condition = true;
        for (int index = 6; index < 9; index++)
        {
            if (_gameButtons[index].GetPlayerIndex() == 0)
            {
                winning_condition = false;
                break;
            }
            
            if (player_checking == 0)
            {
                player_checking = _gameButtons[index].GetPlayerIndex();
            }
            else if (player_checking != _gameButtons[index].GetPlayerIndex())
            {
                winning_condition = false;
                break;
            }
        }

        if (winning_condition)
        {
            EndGame();
            return;
        }
        
        // Check Column
        // Right column
        player_checking = 0;
        winning_condition = true;
        for (int index = 0; index < 9; index+=3)
        {
            if (_gameButtons[index].GetPlayerIndex() == 0)
            {
                winning_condition = false;
                break;
            }
            
            if (player_checking == 0)
            {
                player_checking = _gameButtons[index].GetPlayerIndex();
            }
            else if (player_checking != _gameButtons[index].GetPlayerIndex())
            {
                winning_condition = false;
                break;
            }
        }

        if (winning_condition)
        {
            EndGame();
            return;
        }
        
        // Middle column
        player_checking = 0;
        winning_condition = true;
        for (int index = 1; index < 9; index+=3)
        {
            if (_gameButtons[index].GetPlayerIndex() == 0)
            {
                winning_condition = false;
                break;
            }
            
            if (player_checking == 0)
            {
                player_checking = _gameButtons[index].GetPlayerIndex();
            }
            else if (player_checking != _gameButtons[index].GetPlayerIndex())
            {
                winning_condition = false;
                break;
            }
        }

        if (winning_condition)
        {
            EndGame();
            return;
        }
        
        // Left column
        player_checking = 0;
        winning_condition = true;
        for (int index = 2; index < 9; index+=3)
        {
            if (_gameButtons[index].GetPlayerIndex() == 0)
            {
                winning_condition = false;
                break;
            }
            
            if (player_checking == 0)
            {
                player_checking = _gameButtons[index].GetPlayerIndex();
            }
            else if (player_checking != _gameButtons[index].GetPlayerIndex())
            {
                winning_condition = false;
                break;
            }
        }

        if (winning_condition)
        {
            EndGame();
            return;
        }
        
        // Check diagonals
        // First diagonal (top-left -> bottom-right)
        player_checking = 0;
        winning_condition = true;
        for (int index = 0; index < 9; index+=4)
        {
            if (_gameButtons[index].GetPlayerIndex() == 0)
            {
                winning_condition = false;
                break;
            }
            
            if (player_checking == 0)
            {
                player_checking = _gameButtons[index].GetPlayerIndex();
            }
            else if (player_checking != _gameButtons[index].GetPlayerIndex())
            {
                winning_condition = false;
                break;
            }
        }

        if (winning_condition)
        {
            EndGame();
            return;
        }
        
        // Second diagonal (top-right -> bottom-left)
        player_checking = 0;
        winning_condition = true;
        for (int index = 2; index < 7; index+=2)
        {
            if (_gameButtons[index].GetPlayerIndex() == 0)
            {
                winning_condition = false;
                break;
            }
            
            if (player_checking == 0)
            {
                player_checking = _gameButtons[index].GetPlayerIndex();
            }
            else if (player_checking != _gameButtons[index].GetPlayerIndex())
            {
                winning_condition = false;
                break;
            }
        }

        if (winning_condition)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        foreach (GameGridDetections game_button in  _gameButtons)
        {
            game_button.enabled = false;
        }
        enabled = false;
        
        Destroy(_player1.gameObject);
        Destroy(_player2.gameObject);
        
        SceneManager.LoadScene(0);
    }

    public Player GetCurrentPlayer()
    {
        return _currentPlayer;
    }
}
