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

	[SerializeField] private GameObject dialogueObj;
	[SerializeField] private DialogueRunner dialogue;

	private bool isSeeOpening;

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
			if (isSeeOpening == false)
			{
				isSeeOpening = true;
				dialogue.StartDialogue("1Chapter");
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