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

	public void NewGame()
	{
		GM.Loading("YuriaShop(InSide)");
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
