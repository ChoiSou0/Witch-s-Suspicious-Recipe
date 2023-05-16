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

	DateTime OnlineTime;

	void Start()
	{
		SaveManager.Instance.LoadGameData();
		SaveManager.Instance.SaveGameData();
		yestermonth = SaveManager.Instance.data.yestermonth;
		yesterday = SaveManager.Instance.data.yesterday;
		StartCoroutine(TimeCheck());
	}

	void Update()
	{

	}

	IEnumerator TimeCheck()
	{
		while (true)
		{
			UnityWebRequest request = new UnityWebRequest();
			using (request = UnityWebRequest.Get("www.naver.com"))
			{
				yield return request.SendWebRequest();

				if (request.result == UnityWebRequest.Result.ConnectionError)
				{
					if (request.error == "Cannot connect to destination host")
					{
						Debug.Log("���ͳ� ������ ���������ϴ�");
					}
					else if (request.error == "Failed to receive data")
					{
						Debug.Log("�����͸� �޾ƿ��� ���߽��ϴ�");
					}
					else
					{
						Debug.Log(request.error);
					}
				}
				else
				{
					string date = request.GetResponseHeader("date");
					OnlineTime = DateTime.Parse(date).ToLocalTime();
					txt.text = OnlineTime.ToString();
					TimeRefresh();
				}
			}
			yield return new WaitForSecondsRealtime(0.05f);
		}
	}

	public void TimeRefresh()
	{
		if (OnlineTime.Month > yestermonth || OnlineTime.Day > yesterday)
		{
			yestermonth = OnlineTime.Month;
			yesterday = OnlineTime.Day;
			SaveManager.Instance.data.yesterday = yesterday;
			SaveManager.Instance.data.yestermonth = yestermonth;
			SaveManager.Instance.SaveGameData();
			Debug.Log("��¥ �����");
		}
	}
}
