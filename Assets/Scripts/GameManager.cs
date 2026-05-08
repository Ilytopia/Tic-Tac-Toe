using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.VFX;

public class GameManager : MonoBehaviour
{
    private InputAction _clickAction;

    [SerializeField] private GameObject _clickVFX;
    private Texture _intitialVFXSprite;
    private VisualEffect _visualEffect;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!_clickVFX)
        {
            _clickVFX = FindFirstObjectByType<VisualEffect>().gameObject;
        }
        
        _clickAction = InputSystem.actions.FindAction("Attack");
        _visualEffect = _clickVFX.GetComponent<VisualEffect>();

        _intitialVFXSprite = _visualEffect.GetTexture("Sprite");
        
        // Remove extra GameManagers
        GameManager[] all_game_managers = FindObjectsByType<GameManager>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        if (all_game_managers.Length > 1)
        {
            foreach (GameManager game_manager in all_game_managers)
            {
                if (game_manager == this)
                {
                    continue;
                }
                Destroy(game_manager.gameObject);
            }
        }
        
        // Remove extra ClickVFX
        VisualEffect[] all_effects = FindObjectsByType<VisualEffect>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        if (all_effects.Length > 1)
        {
            foreach (VisualEffect effect in all_effects)
            {
                if (effect == _visualEffect)
                {
                    continue;
                }
                Destroy(effect.gameObject);
            }
        }
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

    public void ChangeVFXSprite(Texture new_texture)
    {
        if (!new_texture)
        {
            _visualEffect.SetBool("IsSpriteSheet", true);
            _visualEffect.SetTexture("Sprite", _intitialVFXSprite);
        }
        else
        {
            _visualEffect.SetBool("IsSpriteSheet", false);
            _visualEffect.SetTexture("Sprite", new_texture);
        }
    }

    public void MainMenu()
    {
        ChangeVFXSprite(null);
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
    }

    public void CustomizationScene()
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }

    public void GameScene()
    {
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Single);
    }

    public void Options()
    {
        //SceneManager.LoadScene("Options");
    }

    public void WinningPopUp(Player winning_player)
    {
        ChangeVFXSprite(null);
        SceneManager.LoadScene("PopUp", LoadSceneMode.Additive);
        // WinningPopup popup = FindFirstObjectByType<WinningPopup>();
        // if (winning_player)
        // {
        //     Debug.Log(popup.name);
        // }
        // popup.InitializePopUp(winning_player);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
