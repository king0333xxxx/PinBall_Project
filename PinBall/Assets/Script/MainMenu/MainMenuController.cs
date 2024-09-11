using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [Header("Reference Button")]
    public Button playButton;
    public Button exitButton;

    private void Start()
    {
        playButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(ExitGame);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Pinball_Game");
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    public void PlayCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void BackTomenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}