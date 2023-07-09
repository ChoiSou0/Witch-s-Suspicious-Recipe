using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class GameManager : MonoBehaviour
{
	[SerializeField] private GameObject player;
	private float[] warploc;
	private bool isWarp;
	public bool isWarped;

	public DialogueRunner dialogue;

	[HideInInspector] public bool isSeeOpening1;
	[HideInInspector] public bool isSeeOpening2;
	[HideInInspector] public bool isSeeOpening3;

	private void Start()
	{
		SceneManager.sceneLoaded += SceneLoaded;
		SceneManager.LoadScene("TitleScene");
	}

	public void Loading(string scenename)
	{
		StartCoroutine(LoadDelay(scenename));
	}
	public void Warp(string scenename, float[] loc)
	{
		warploc = loc;
		isWarp = true;
		isWarped = true;
		StartCoroutine(LoadDelay(scenename));
	}

	private void SceneLoaded(Scene scene, LoadSceneMode mode)
	{
		if (scene.name == "YuriaShop(InSide)")
		{
			if (isSeeOpening1 == false)
			{
				isSeeOpening1 = true;
				dialogue.StartDialogue("1Chapter-1");
			}
		}
	}

	IEnumerator LoadDelay(string scenename)
	{
		player.SetActive(false);
		SceneManager.LoadScene("LoadScene");
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene(scenename);
		player.SetActive(true);
	}
}