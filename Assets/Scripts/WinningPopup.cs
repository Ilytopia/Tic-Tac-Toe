using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class WinningPopup : MonoBehaviour
{
    private Sprite _winnerSprite;
    private string _winnerName;
    
    [SerializeField] private TextMeshProUGUI _winnerText;
    [SerializeField] private Image _winnerImage;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void InitializePopUp(Player winning_player)
    {
        _winnerName = winning_player.gameObject.name;
        _winnerSprite = winning_player.gameObject.GetComponent<SpriteRenderer>().sprite;

        _winnerText.text = _winnerName + " wins !";
        _winnerImage.sprite = _winnerSprite;
    }
}
