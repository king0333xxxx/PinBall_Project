using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerGameOver : MonoBehaviour
{
    [Header("Reference")]
    public Collider bola;
    public GameObject gameOverCanvas;

    [Header("Reference Sfx/VFx")]
    // tambahkan audio manager untuk mengakses fungsi pada audio managernya
    public AudioManager audioManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
            audioManager.PlayGameOverSFX(other.transform.position);

            // kembali ke main menu
            gameOverCanvas.SetActive(true);
        }
    }
}
