using System;
using UnityEngine;

public class ChoosableCharacter : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private bool _characterChosen;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public SpriteRenderer GetSpriteRenderer()
    {
        return _spriteRenderer;
    }

    public bool GetCharacterChosen()
    {
        return _characterChosen;
    }

    public void SetCharacterChosen(bool character_chosen)
    {
        _characterChosen = character_chosen;
    }
}
