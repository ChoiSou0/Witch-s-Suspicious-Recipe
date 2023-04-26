using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
	public TextMeshProUGUI txt;
	private int yesterday;

	void Start()
	{
		yesterday = DateTime.Now.Day;
	}

	void Update()
	{
		txt.text = DateTime.Now.ToString();
		if (Input.GetKeyDown(KeyCode.Q))
		{
			TimeRefresh();
		}
	}

	public void TimeRefresh()
	{
		if (DateTime.Now.Day > yesterday)
		{
			yesterday = DateTime.Now.Day;
			Debug.Log("³¯Â¥ º¯°æµÊ");
		}
	}
}
