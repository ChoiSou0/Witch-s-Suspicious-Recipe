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
		public string questName;
		public string questDiscription;
		public float questGoal;
		public float questCount;
		public Sprite questImage;

		public QuestOrig(string questName, string questDiscription, float questGoal, float questCount, Sprite questImage)
		{
			this.questName = questName;
			this.questDiscription = questDiscription;
			this.questGoal = questGoal;
			this.questCount = questCount;
			this.questImage = questImage;
		}
	}

	public GameObject[] QuestPannel = new GameObject[3];

	public List<QuestOrig> QuestList = new List<QuestOrig>();

	//public float QuestCount;
	//public float QuestGoalGlobal;

	public List<string> QuestItem;
	public int[] questNum;

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
			QuestList[questNum[0]] = new QuestOrig(QuestList[questNum[0]].questName, QuestList[questNum[0]].questDiscription, QuestList[questNum[0]].questGoal, QuestList[questNum[0]].questCount + 1, QuestList[questNum[0]].questImage);
			QuestList[questNum[1]] = new QuestOrig(QuestList[questNum[1]].questName, QuestList[questNum[1]].questDiscription, QuestList[questNum[1]].questGoal, QuestList[questNum[1]].questCount + 1, QuestList[questNum[1]].questImage);
			QuestList[questNum[2]] = new QuestOrig(QuestList[questNum[2]].questName, QuestList[questNum[2]].questDiscription, QuestList[questNum[2]].questGoal, QuestList[questNum[2]].questCount + 1, QuestList[questNum[2]].questImage);
			QuestPannel[0].gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = QuestList[questNum[0]].questCount + " / " + QuestList[questNum[0]].questGoal;
			QuestPannel[1].gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = QuestList[questNum[1]].questCount + " / " + QuestList[questNum[1]].questGoal;
			QuestPannel[2].gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = QuestList[questNum[2]].questCount + " / " + QuestList[questNum[2]].questGoal;
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
		questNum = new int[] { -1, -1, -1 };
		for (int i = 0; i < 3; i++)
		{
			int Index = Random.Range(0, QuestList.Count);
			if (Array.IndexOf(questNum, Index) == -1)
			{
				QuestOrig QuestData = QuestList[Index];
				QuestPannel[i].gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QuestData.questName;
				//QuestNameText.text = QuestData.QuestName;
				QuestPannel[i].gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = QuestData.questDiscription + "을(를) " + QuestData.questGoal + "개 가져오기";
				//QuestDiscriptionText.text = QuestData.QuestDiscription + "을(를) " + QuestData.QuestGoal + "개 가져오기";
				//QuestGoalGlobal = QuestData.QuestGoal;
				//QuestCount = 0;
				QuestPannel[i].gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = QuestData.questCount + " / " + QuestData.questGoal;
				//QuestCountText.text = QuestCount + " / " + QuestGoalGlobal;
				questNum[i] = Index;
				i++;
			}
			i--;
		}
		Debug.Log(questNum[0]);
		Debug.Log(questNum[1]);
		Debug.Log(questNum[2]);
	}

	public void AddQuest(string QuestName, string QuestDiscription, float QuestGoal, Sprite QuestImage)
	{
		QuestOrig temp = new QuestOrig();
		temp.questName = QuestName;
		temp.questDiscription = QuestDiscription;
		temp.questGoal = QuestGoal;
		temp.questImage = QuestImage;
		QuestList.Add(temp);
	}
}