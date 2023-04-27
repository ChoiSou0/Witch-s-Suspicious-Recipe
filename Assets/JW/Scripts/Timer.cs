using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class Timer : MonoBehaviour
{
	public TextMeshProUGUI txt;
	private int yestermonth;
	private int yesterday;

	void Start()
	{
		SaveManager.Instance.LoadGameData();
		SaveManager.Instance.SaveGameData();
		yestermonth = SaveManager.Instance.data.yestermonth;
		yesterday = SaveManager.Instance.data.yesterday;
	}

	void Update()
	{
		txt.text = DateTime.Now.ToString();
		if (Input.GetKeyDown(KeyCode.Q))
		{
			TimeRefresh();
		}
	}

	IEnumerator TimeCheck()
	{
		UnityWebRequest request = new UnityWebRequest();
		using (request = UnityWebRequest.Get("www.naver.com"))
		{
			yield return request.SendWebRequest();

			if (request.isNetworkError)
			{
				Debug.Log(request.error);
			}
			else
			{
				string date = request.GetResponseHeader("date");
				Debug.Log("받아온 시간" + date);
				DateTime dateTime = DateTime.Parse(date).ToLocalTime();
				Debug.Log("한국시간으로변환" + dateTime);
			}
		}
	}

	public void TimeRefresh()
	{
		StartCoroutine(TimeCheck());
		if (DateTime.Now.Month > yestermonth || DateTime.Now.Day > yesterday)
		{
			yestermonth = DateTime.Now.Month;
			yesterday = DateTime.Now.Day;
			SaveManager.Instance.data.yesterday = yesterday;
			SaveManager.Instance.data.yestermonth = yestermonth;
			SaveManager.Instance.SaveGameData();
			Debug.Log("날짜 변경됨");
		}
	}
}
