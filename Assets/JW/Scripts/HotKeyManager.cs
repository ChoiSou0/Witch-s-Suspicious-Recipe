using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotKeyManager : MonoBehaviour
{
	[SerializeField] private GameObject escMenu;

	void Start()
	{

	}

	void Update()
	{
		Hotkey();
	}

	private void Hotkey()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			escMenu.SetActive(true);
		}
	}
}