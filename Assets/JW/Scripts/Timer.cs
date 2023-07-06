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

	private DateTime onlineTime;

	void Start()
	{
		SaveManager.Instance.LoadGameData();
		yestermonth = SaveManager.Instance.data.yestermonth;
		yesterday = SaveManager.Instance.data.yesterday;
		StartCoroutine(TimeCheck());
	}

	IEnumerator TimeCheck()
	{
		while (true)
		{
			using (UnityWebRequest request = UnityWebRequest.Get("http://www.naver.com"))
			{
				yield return request.SendWebRequest();

				if (request.result == UnityWebRequest.Result.ConnectionError)
				{
					if (request.error == "Cannot connect to destination host")
					{
						Debug.Log("인터넷 연결이 끊어졌습니다");
					}
					else if (request.error == "Failed to receive data")
					{
						Debug.Log("데이터를 받아오지 못했습니다");
					}
					else
					{
						Debug.Log(request.error);
					}
				}
				else
				{
					string date = request.GetResponseHeader("date");
					onlineTime = DateTime.Parse(date).ToLocalTime();
					txt.text = onlineTime.ToString();
					TimeRefresh();
				}
			}
			yield return new WaitForSecondsRealtime(0.05f);
		}
	}

	public void TimeRefresh()
	{
		if (onlineTime.Month > yestermonth || onlineTime.Day > yesterday)
		{
			yestermonth = onlineTime.Month;
			yesterday = onlineTime.Day;
			SaveManager.Instance.data.yesterday = yesterday;
			SaveManager.Instance.data.yestermonth = yestermonth;
			SaveManager.Instance.SaveGameData();
			Debug.Log("날짜 변경됨");
		}
	}
}