using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TimeManager : MonoBehaviour
{
	public Light2D globalLight;
	public TextMeshProUGUI timeText;
	public bool morning;
	public int loopnum = 0;

	void Start()
	{
		StartCoroutine(TimeLight());
	}

	void Update()
	{

	}

	IEnumerator TimeLight()
	{
		//int loopnum = 0;
		string hour;
		string min;
		string sec;
		int day = 60 * 60 * 24;
		int scale = 10;
		while (true)
		{
			if (globalLight.intensity <= 0)
			{
				morning = false;
			}
			if (globalLight.intensity >= 1)
			{
				morning = true;
			}
			if (morning == false)
			{
				globalLight.intensity = globalLight.intensity + 1f / day * scale;
				//1/86400
				//loopnum++;
				loopnum += scale;
			}
			else
			{
				globalLight.intensity = globalLight.intensity - 1f / day * scale;
				//1/86400
				//loopnum++;
				loopnum += scale;
			}

			hour = (loopnum / 3600).ToString();
			min = (loopnum % 3600 / 60).ToString();
			sec = (loopnum % 60).ToString();

			if (int.Parse(hour) < 10)
			{
				hour = "0" + hour;
			}
			if (int.Parse(min) < 10)
			{
				min = "0" + min;
			}
			if (int.Parse(sec) < 10)
			{
				sec = "0" + sec;
			}

			timeText.text = hour + ":" + min + ":" + sec;
			yield return new WaitForSeconds(0.0001f);
		}
	}
}
