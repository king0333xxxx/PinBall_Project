using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRampController : MonoBehaviour
{
    [Header("Reference Score")]
    public float score;
    public ScoreManager scoreManager;

    [Header("Reference Object")]
    public Collider bola;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
            //tambah skor kalau terkena bola
            scoreManager.AddScore(score);
        }
    }
}
