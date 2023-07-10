using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class YarnScript : MonoBehaviour
{
	public SoundManager soundManager;

	public GameObject Background;

	public Player Player;

	public GameObject PlayerImg;
	public GameObject DogImg;
	public GameObject GlassImg;

	[YarnCommand("PlaySE")]
	public void PlaySE()
	{
		Debug.Log("d");
		soundManager.PlaySE(Resources.Load<AudioClip>("Clip/MP_Pew Pew"));
	}

	[YarnCommand("DialogueStart")]
	public void DialogueStart()
	{
		Player.GetComponent<Player>().DontMove = true;
	}

	[YarnCommand("DialogueEnd")]
	public void DialogueEnd()
	{
		Player.GetComponent<Player>().DontMove = false;
		PlayerImg.SetActive(false);
		DogImg.SetActive(false);
		GlassImg.SetActive(false);
	}

	[YarnCommand("BGOn")]
	public void BGOn()
	{
		Background.SetActive(true);
	}

	[YarnCommand("BGOff")]
	public void BGOff()
	{
		Background.SetActive(false);
	}

	[YarnCommand("ChaOn")]
	public void ChaOn(string name)
	{
		if (name == "Player")
		{
			PlayerImg.SetActive(true);
		}
		else if (name == "Dog")
		{
			DogImg.SetActive(true);
		}
		else if (name == "Glass")
		{
			GlassImg.SetActive(true);
		}
	}

	[YarnCommand("ChaOff")]
	public void ChaOff(string name)
	{
		if (name == "Player")
		{
			PlayerImg.SetActive(false);
		}
		else if (name == "Dog")
		{
			DogImg.SetActive(false);
		}
		else if (name == "Glass")
		{
			GlassImg.SetActive(false);
		}
	}

	[YarnCommand("ChaWhite")]
	public void ChaWhite(string name)
	{
		if (name == "Player")
		{
			PlayerImg.GetComponent<Image>().color = new Color(255f / 255f, 255f / 255f, 255f / 255f);
		}
		else if (name == "Dog")
		{
			DogImg.GetComponent<Image>().color = new Color(255f / 255f, 255f / 255f, 255f / 255f);
		}
		else if (name == "Glass")
		{
			GlassImg.GetComponent<Image>().color = new Color(255f / 255f, 255f / 255f, 255f / 255f);
		}
	}

	[YarnCommand("ChaBlack")]
	public void ChaBlack(string name)
	{
		if (name == "Player")
		{
			PlayerImg.GetComponent<Image>().color = new Color(128f / 255f, 128f / 255f, 128f / 255f);
		}
		else if (name == "Dog")
		{
			DogImg.GetComponent<Image>().color = new Color(128f / 255f, 128f / 255f, 128f / 255f);
		}
		else if (name == "Glass")
		{
			GlassImg.GetComponent<Image>().color = new Color(128f / 255f, 128f / 255f, 128f / 255f);
		}
	}

	[YarnCommand("ChaUnknown")]
	public void ChaUnknown(string name)
	{
		if (name == "Player")
		{
			PlayerImg.GetComponent<Image>().color = new Color(0f / 255f, 0f / 255f, 0f / 255f);
		}
		else if (name == "Dog")
		{
			DogImg.GetComponent<Image>().color = new Color(0f / 255f, 0f / 255f, 0f / 255f);
		}
		else if (name == "Glass")
		{
			GlassImg.GetComponent<Image>().color = new Color(0f / 255f, 0f / 255f, 0f / 255f);
		}
	}
}
