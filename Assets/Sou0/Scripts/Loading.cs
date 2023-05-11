using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
	private Animator LoadingAni;


	void Start()
	{
		LoadingAni = GameObject.Find("LoadingAni").GetComponent<Animator>();

		switch (Random.Range(0, 2))
		{
			case 0:
				LoadingAni.SetBool("AniType", true);
				break;
			case 1:
				LoadingAni.SetBool("AniType", false);
				break;
		}

	}

	void Update()
	{

	}
}
