using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

using Random = UnityEngine.Random;

public class QuestManager : MonoBehaviour
{
	public struct QuestOrig
	{
		public string QuestName;
		public string QuestDiscription;
		public float QuestGoal;
		public float QuestCount;
		public Sprite QuestImage;

		public QuestOrig(string QuestName, string QuestDiscription, float QuestGoal, float QuestCount, Sprite QuestImage)
		{
			this.QuestName = QuestName;
			this.QuestDiscription = QuestDiscription;
			this.QuestGoal = QuestGoal;
			this.QuestCount = QuestCount;
			this.QuestImage = QuestImage;
		}
	}

	public GameObject[] QuestPannel = new GameObject[3];

	public List<QuestOrig> QuestList = new List<QuestOrig>();

	//public float QuestCount;
	//public float QuestGoalGlobal;

	public List<string> QuestItem;
	public int[] QuestNum;

	void Start()
	{
		SettingQuest();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			AddQuest("Quest Test", QuestItem[Random.Range(0, QuestItem.Count)], Random.Range(0, 101), Resources.Load("1") as Sprite);
		}
		if (Input.GetKeyDown(KeyCode.W))
		{
			ResetQuest();
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			//QuestCount++;
			QuestList[QuestNum[0]] = new QuestOrig(QuestList[QuestNum[0]].QuestName, QuestList[QuestNum[0]].QuestDiscription, QuestList[QuestNum[0]].QuestGoal, QuestList[QuestNum[0]].QuestCount + 1, QuestList[QuestNum[0]].QuestImage);
			QuestList[QuestNum[1]] = new QuestOrig(QuestList[QuestNum[1]].QuestName, QuestList[QuestNum[1]].QuestDiscription, QuestList[QuestNum[1]].QuestGoal, QuestList[QuestNum[1]].QuestCount + 1, QuestList[QuestNum[1]].QuestImage);
			QuestList[QuestNum[2]] = new QuestOrig(QuestList[QuestNum[2]].QuestName, QuestList[QuestNum[2]].QuestDiscription, QuestList[QuestNum[2]].QuestGoal, QuestList[QuestNum[2]].QuestCount + 1, QuestList[QuestNum[2]].QuestImage);
			QuestPannel[0].gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = QuestList[QuestNum[0]].QuestCount + " / " + QuestList[QuestNum[0]].QuestGoal;
			QuestPannel[1].gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = QuestList[QuestNum[1]].QuestCount + " / " + QuestList[QuestNum[1]].QuestGoal;
			QuestPannel[2].gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = QuestList[QuestNum[2]].QuestCount + " / " + QuestList[QuestNum[2]].QuestGoal;
			//if (QuestCount >= QuestGoalGlobal)
			//{
			//	Debug.Log("Clear");
			//}
		}
	}

	public void SettingQuest()
	{
		AddQuest("Quest Test", QuestItem[Random.Range(0, QuestItem.Count)], Random.Range(0, 101), Resources.Load("1") as Sprite);
		AddQuest("Quest Test", QuestItem[Random.Range(0, QuestItem.Count)], Random.Range(0, 101), Resources.Load("1") as Sprite);
		AddQuest("Quest Test", QuestItem[Random.Range(0, QuestItem.Count)], Random.Range(0, 101), Resources.Load("1") as Sprite);
		//AddQuest("호박을 찾아서", "호박", 10, Resources.Load("1") as Sprite);
		//AddQuest("수박을 찾아서", "수박", 10, Resources.Load("1") as Sprite);
		//AddQuest("박을 찾아서", "박", 10, Resources.Load("1") as Sprite);
	}

	public void ResetQuest()
	{
		QuestNum = new int[] { -1, -1, -1 };
		for (int i = 0; i < 3; i++)
		{
			int Index = Random.Range(0, QuestList.Count);
			if (Array.IndexOf(QuestNum, Index) == -1)
			{
				QuestOrig QuestData = QuestList[Index];
				QuestPannel[i].gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QuestData.QuestName;
				//QuestNameText.text = QuestData.QuestName;
				QuestPannel[i].gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = QuestData.QuestDiscription + "을(를) " + QuestData.QuestGoal + "개 가져오기";
				//QuestDiscriptionText.text = QuestData.QuestDiscription + "을(를) " + QuestData.QuestGoal + "개 가져오기";
				//QuestGoalGlobal = QuestData.QuestGoal;
				//QuestCount = 0;
				QuestPannel[i].gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = QuestData.QuestCount + " / " + QuestData.QuestGoal;
				//QuestCountText.text = QuestCount + " / " + QuestGoalGlobal;
				QuestNum[i] = Index;
				i++;
			}
			i--;
		}
		Debug.Log(QuestNum[0]);
		Debug.Log(QuestNum[1]);
		Debug.Log(QuestNum[2]);
	}

	public void AddQuest(string QuestName, string QuestDiscription, float QuestGoal, Sprite QuestImage)
	{
		QuestOrig temp = new QuestOrig();
		temp.QuestName = QuestName;
		temp.QuestDiscription = QuestDiscription;
		temp.QuestGoal = QuestGoal;
		temp.QuestImage = QuestImage;
		QuestList.Add(temp);
	}
}