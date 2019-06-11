using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinController : Singleton<WinController>
{
    public GameObject winScreen;
    public Text textScore;
    public Button buttonRestart;

    public bool IsGame { get; private set; } = true;

    private void Start()
    {
        buttonRestart.onClick.AddListener(ButtonRestart);
    }

    public void ShowScreen()
    {
        winScreen.SetActive(true);
        textScore.text = $"Набрано очков: {CargoController.Instance.Score}";
        IsGame = false;
    }

    private void ButtonRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
