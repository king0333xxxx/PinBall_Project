using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

	[Header("Reference BGM")]
	// kita masukan audio source bgm disini
	public AudioSource bgmAudioSource;

	[Header("Reference Sfx")]
	// kita masukan game object sfx disini
	public GameObject sfxBumperAudioSource;
	public GameObject sfxSwitchAudioSource;
	public GameObject sfxGameOverAudioSource;



	private void Start()
	{
		// jalankan BGM saat game dimulai
		PlayBGM();
	}

	// fungsi yang disiapkan untuk perintah menjalankan bgm dari script lain
	public void PlayBGM()
	{
		// kita tinggal tambahkan saja fungsi untuk memainkan audio source bgm nya
		bgmAudioSource.Play();
	}
	// fungsi yang disiapkan untuk perintah menjalankan sfx dari script lain
	public void PlayBumperSFX(Vector3 spawnPosition) 
	{
		// memunculkan prefabnya pada posisi sesuai dengan parameternya
		GameObject.Instantiate(sfxBumperAudioSource, spawnPosition, Quaternion.identity);
	}

	public void PlaySwitchSFX(Vector3 spawnPosition)
	{
		// memunculkan prefabnya pada posisi sesuai dengan parameternya
		GameObject.Instantiate(sfxSwitchAudioSource, spawnPosition, Quaternion.identity);
	}
	public void PlayGameOverSFX(Vector3 spawnPosition)
	{
		// memunculkan prefabnya pada posisi sesuai dengan parameternya
		GameObject.Instantiate(sfxGameOverAudioSource, spawnPosition, Quaternion.identity);
	}

}
