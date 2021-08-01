using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextSender : MonoBehaviour
{
    [SerializeField] Text text;

    private void OnEnable()
    {
        GameLogic.OnPlayerChange += ChangeText;
        GameLogic.OnGameOver += GameOver;
    }
    private void OnDisable()
    {
        GameLogic.OnPlayerChange -= ChangeText;
        GameLogic.OnGameOver -= GameOver;
    }

    private void Start()
    {
        text.text = "It's turn of Player One";
    }
    public void ChangeText(string name)
    {
        text.text = $"It's turn of {name}";
    }
    public void GameOver(string name)
    {
        text.text = $"{name} won!";
    }
}
