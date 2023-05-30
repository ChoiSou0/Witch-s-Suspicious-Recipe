using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

using Random = UnityEngine.Random;
using UnityEditor.Search;

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

	public GameObject[] questPannel = new GameObject[3];

	public List<QuestOrig> questList = new List<QuestOrig>();

	//public float QuestCount;
	//public float QuestGoalGlobal;

	public List<string> questItem;
	public int[] questNum;

	void Start()
	{
		SettingQuest();
		ResetQuest();
	}

	public void AddQuest()
	{
		AddQuest("Quest Test", questItem[Random.Range(0, questItem.Count)], Random.Range(0, 101), Resources.Load<Sprite>("Image"));
	}

	public void AddQuestPoint()
	{
		//QuestCount++;
		Debug.Log(questList[questNum[0]].questName + " / " + questList[questNum[0]].questDiscription + "을(를) " + questList[questNum[0]].questGoal + "개 가져오기 퀘스트에 포인트 1 추가 (" + questList[questNum[0]].questCount + "->" + (questList[questNum[0]].questCount + 1) + ")");
		Debug.Log(questList[questNum[1]].questName + " / " + questList[questNum[1]].questDiscription + "을(를) " + questList[questNum[1]].questGoal + "개 가져오기 퀘스트에 포인트 1 추가 (" + questList[questNum[1]].questCount + "->" + (questList[questNum[1]].questCount + 1) + ")");
		Debug.Log(questList[questNum[2]].questName + " / " + questList[questNum[2]].questDiscription + "을(를) " + questList[questNum[2]].questGoal + "개 가져오기 퀘스트에 포인트 1 추가 (" + questList[questNum[2]].questCount + "->" + (questList[questNum[2]].questCount + 1) + ")");
		questList[questNum[0]] = new QuestOrig(questList[questNum[0]].questName, questList[questNum[0]].questDiscription, questList[questNum[0]].questGoal, questList[questNum[0]].questCount + 1, questList[questNum[0]].questImage);
		questList[questNum[1]] = new QuestOrig(questList[questNum[1]].questName, questList[questNum[1]].questDiscription, questList[questNum[1]].questGoal, questList[questNum[1]].questCount + 1, questList[questNum[1]].questImage);
		questList[questNum[2]] = new QuestOrig(questList[questNum[2]].questName, questList[questNum[2]].questDiscription, questList[questNum[2]].questGoal, questList[questNum[2]].questCount + 1, questList[questNum[2]].questImage);
		questPannel[0].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = questList[questNum[0]].questCount + " / " + questList[questNum[0]].questGoal;
		questPannel[1].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = questList[questNum[1]].questCount + " / " + questList[questNum[1]].questGoal;
		questPannel[2].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = questList[questNum[2]].questCount + " / " + questList[questNum[2]].questGoal;
		//if (QuestCount >= QuestGoalGlobal)
		//{
		//	Debug.Log("Clear");
		//}
	}

	public void SettingQuest()
	{
		AddQuest("Quest Test", questItem[Random.Range(0, questItem.Count)], Random.Range(0, 101), Resources.Load<Sprite>("character_Mode@4x"));
		AddQuest("Quest Test", questItem[Random.Range(0, questItem.Count)], Random.Range(0, 101), Resources.Load<Sprite>("Copy@4x"));
		AddQuest("Quest Test", questItem[Random.Range(0, questItem.Count)], Random.Range(0, 101), Resources.Load<Sprite>("Create Bones@4x"));
	}

	public void ResetQuest()
	{
		questNum = new int[] { -1, -1, -1 };
		for (int i = 0; i < 3;)
		{
			int Index = Random.Range(0, questList.Count);
			if (Array.IndexOf(questNum, Index) == -1)
			{
				QuestOrig QuestData = questList[Index];
				questPannel[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QuestData.questName;
				//QuestNameText.text = QuestData.QuestName;
				questPannel[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = QuestData.questDiscription + "을(를) " + QuestData.questGoal + "개 가져오기";
				//QuestDiscriptionText.text = QuestData.QuestDiscription + "을(를) " + QuestData.QuestGoal + "개 가져오기";
				//QuestGoalGlobal = QuestData.QuestGoal;
				//QuestCount = 0;
				questPannel[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = QuestData.questCount + " / " + QuestData.questGoal;
				questPannel[i].transform.GetChild(3).GetComponent<Image>().sprite = QuestData.questImage;
				//QuestCountText.text = QuestCount + " / " + QuestGoalGlobal;
				questNum[i] = Index;
				i++;
			}
		}
		Debug.Log("퀘스트 목록 초기화 완료");
	}

	public void AddQuest(string QuestName, string QuestDiscription, float QuestGoal, Sprite QuestImage)
	{
		QuestOrig temp = new QuestOrig();
		temp.questName = QuestName;
		temp.questDiscription = QuestDiscription;
		temp.questGoal = QuestGoal;
		temp.questImage = QuestImage;
		questList.Add(temp);
		Debug.Log($"{QuestName} / {QuestDiscription}을(를) {QuestGoal}개 가져오기 퀘스트 추가");
	}
}