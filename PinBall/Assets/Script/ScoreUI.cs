using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
	// reference ke text score nya
    [Header("Reference")]
	public TMP_Text scoreText;

	// reference ke score manager
	public ScoreManager scoreManager;

	private void Update()
	{
		// agar lebih mudah, tiap update kita set aja angak score text nya menjadi angka score
		scoreText.text = scoreManager.score.ToString();
	}
}
