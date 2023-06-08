using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TimeManager : MonoBehaviour
{
	public Light2D globalLight;
	public TextMeshProUGUI timeText;
	private bool ttt;

	void Start()
	{
		StartCoroutine(TimeLight());
	}

	void Update()
	{

	}

	IEnumerator TimeLight()
	{
		int loopnum = 0;
		string hour;
		string min;
		string sec;
		while (true)
		{
			if (globalLight.intensity <= 0)
			{
				ttt = false;
			}
			if (globalLight.intensity >= 1)
			{
				ttt = true;
			}
			if (ttt == false)
			{
				globalLight.intensity = globalLight.intensity + 0.001388888888888889f;
				//1/720
				loopnum++;
			}
			else
			{
				globalLight.intensity = globalLight.intensity - 0.001388888888888889f;
				//1/720
				loopnum++;
			}

			print(loopnum);
			hour = (loopnum / 60).ToString();
			min = (loopnum % 60).ToString();

			if (int.Parse(hour) >= 24)
			{
				loopnum -= 1440;
			}

			if (int.Parse(hour) < 10)
			{
				hour = "0" + hour;
			}
			if (int.Parse(min) < 10)
			{
				min = "0" + min;
			}

			timeText.text = hour + ":" + min + ":00";
			yield return new WaitForSeconds(0.001f);
		}
	}
}
