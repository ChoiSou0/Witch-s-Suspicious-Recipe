using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
	private GameManager GM;

	void Start()
	{
		GM = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	void Update()
	{

	}

	public void NewGame()
	{
		GM.Loading("Prepare");
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
