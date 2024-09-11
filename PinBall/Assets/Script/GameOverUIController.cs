using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUIController : MonoBehaviour
{
    [Header("Reference Button")]
    // reference untuk button
    public Button mainMenuButton;
    public Button restartButton;

    private void Start()
    {
        gameObject.SetActive(false);
        // setup event saat button di klik
        mainMenuButton.onClick.AddListener(MainMenu);
        restartButton.onClick.AddListener(Restart);
    }

    public void MainMenu()
    {
        // kembali ke main menu
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Pinball_Game");

    }
}
