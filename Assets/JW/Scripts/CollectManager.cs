using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CollectManager : MonoBehaviour
{
	public bool[] MagicList = new bool[50];

	public void AddMagic(int Magic)
	{
		MagicList[Magic] = true;
		EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color = new Color(0, 1, 0);
	}
}
