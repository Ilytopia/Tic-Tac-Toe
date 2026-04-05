using System;
using TMPro;
using UnityEngine;
using Random = System.Random;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] private GameObject _player1;
    [SerializeField] private GameObject _player2;

    private int _currentRound = 1;

    [SerializeField] private GameObject _currentPlayer;
    private Random  _random =  new Random();

    private GameObject[] _gameButtons;
    
    [SerializeField] private TMP_Text _currentPlayerRoundText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player1 = GameObject.FindGameObjectWithTag("Player1");
        _player2 = GameObject.FindGameObjectWithTag("Player2");

        if (_player1 == null || _player2 == null)
        {
            throw new NotImplementedException();
        }
        
        _gameButtons = GameObject.FindGameObjectsWithTag("GameButton");

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

        _currentPlayerRoundText.text = _currentPlayer.ToString();
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
        
        _currentPlayerRoundText.text = _currentPlayer.ToString();
    }

    private void CheckWinningCondition()
    {
        
    }
}
