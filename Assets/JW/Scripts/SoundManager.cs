using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	AudioSource audioSource;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	void Update()
	{
		
	}

	public void PlaySE(AudioClip audioClip)
	{
		audioSource.clip = audioClip;
		audioSource.Play();
	}
}