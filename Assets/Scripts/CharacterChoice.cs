using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterChoice : MonoBehaviour
{
    private Player _player1;
    private Player _player2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<Player>();
        _player2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Player>();
        
        _player2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
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
