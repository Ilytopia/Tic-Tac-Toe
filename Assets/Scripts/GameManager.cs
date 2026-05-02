using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.VFX;

public class GameManager : MonoBehaviour
{
    private InputAction _clickAction;

    [SerializeField] private GameObject _clickVFX;
    private VisualEffect _visualEffect;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _clickAction = InputSystem.actions.FindAction("Attack");
        _visualEffect = _clickVFX.GetComponent<VisualEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_clickAction.WasPressedThisFrame())
        {
            _clickVFX.transform.position = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            _clickVFX.transform.position = new  Vector3(_clickVFX.transform.position.x, _clickVFX.transform.position.y, -1.0f);
            _visualEffect.Reinit();
            _visualEffect.Play();
        }
    }

    public void StartGameLocal()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Options()
    {
        //SceneManager.LoadScene("Options");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
