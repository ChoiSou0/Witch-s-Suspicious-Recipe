using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceObj : MonoBehaviour
{
	public GameObject copyObj;

	private PlaceManager PM;
	private Image image;

	void Start()
	{
		PM = GameObject.Find("PlaceManager").GetComponent<PlaceManager>();
		image = GetComponent<Image>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		PM.crashCount++;
		image.color = new Color(1, 0, 0, 100f / 255);
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		PM.crashCount--;
		image.color = new Color(1, 1, 1);
	}
}
