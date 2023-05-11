using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	private string loadscene;

	void Start()
	{

	}

	void Update()
	{

	}

	public void Loading(string ls)
	{
		SceneManager.LoadScene("LoadScene");
		loadscene = ls;
		Invoke("LoadDealy", 2f);
	}

	private void LoadDealy()
	{
		SceneManager.LoadScene(loadscene);
	}
}
