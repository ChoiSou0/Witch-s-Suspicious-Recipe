using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class YarnScript : MonoBehaviour
{
	public SoundManager soundManager;

	public GameObject Background;

	public GameObject Player;
	public GameObject Dog;
	public GameObject Glass;

	[YarnCommand("PlaySE")]
	public void PlaySE()
	{
		Debug.Log("d");
		soundManager.PlaySE(Resources.Load<AudioClip>("Clip/MP_Pew Pew"));
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
			Player.SetActive(true);
		}
		else if (name == "Dog")
		{
			Dog.SetActive(true);
		}
		else if (name == "Glass")
		{
			Glass.SetActive(true);
		}
	}

	[YarnCommand("ChaOff")]
	public void ChaOff(string name)
	{
		if (name == "Player")
		{
			Player.SetActive(false);
		}
		else if (name == "Dog")
		{
			Dog.SetActive(false);
		}
		else if (name == "Glass")
		{
			Glass.SetActive(false);
		}
	}

	[YarnCommand("ChaWhite")]
	public void ChaWhite(string name)
	{
		if (name == "Player")
		{
			Player.GetComponent<Image>().color = new Color(255f / 255f, 255f / 255f, 255f / 255f);
		}
		else if (name == "Dog")
		{
			Dog.GetComponent<Image>().color = new Color(255f / 255f, 255f / 255f, 255f / 255f);
		}
		else if (name == "Glass")
		{
			Glass.GetComponent<Image>().color = new Color(255f / 255f, 255f / 255f, 255f / 255f);
		}
	}

	[YarnCommand("ChaBlack")]
	public void ChaBlack(string name)
	{
		if (name == "Player")
		{
			Player.GetComponent<Image>().color = new Color(128f / 255f, 128f / 255f, 128f / 255f);
		}
		else if (name == "Dog")
		{
			Dog.GetComponent<Image>().color = new Color(128f / 255f, 128f / 255f, 128f / 255f);
		}
		else if (name == "Glass")
		{
			Glass.GetComponent<Image>().color = new Color(128f / 255f, 128f / 255f, 128f / 255f);
		}
	}

	[YarnCommand("ChaUnknown")]
	public void ChaUnknown(string name)
	{
		if (name == "Player")
		{
			Player.GetComponent<Image>().color = new Color(0f / 255f, 0f / 255f, 0f / 255f);
		}
		else if (name == "Dog")
		{
			Dog.GetComponent<Image>().color = new Color(0f / 255f, 0f / 255f, 0f / 255f);
		}
		else if (name == "Glass")
		{
			Glass.GetComponent<Image>().color = new Color(0f / 255f, 0f / 255f, 0f / 255f);
		}
	}
}
