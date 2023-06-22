using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField] private GameObject player;
	private float[] warploc;
	private bool isWarp;

	private void Start()
	{
		SceneManager.sceneLoaded += SceneLoaded;
	}

	public void Loading(string ls)
	{
		StartCoroutine(LoadDelay(ls));
	}
	public void Warp(string scenename, float[] loc)
	{
		isWarp = true;
		SceneManager.LoadScene(scenename);
		warploc = loc;
	}

	private void SceneLoaded(Scene scene, LoadSceneMode mode)
	{
		if (isWarp == true)
		{
			isWarp = false;
			player.transform.localPosition = new Vector2(warploc[0], warploc[1]);
		}
	}

	IEnumerator LoadDelay(string ls)
	{
		SceneManager.LoadScene("LoadScene");
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene(ls);
	}
}