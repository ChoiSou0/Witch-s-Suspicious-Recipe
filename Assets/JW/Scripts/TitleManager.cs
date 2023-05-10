using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
	void Start()
	{

	}

	void Update()
	{

	}

	public void NewGame()
	{
		SceneManager.LoadScene("Prepare");
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
