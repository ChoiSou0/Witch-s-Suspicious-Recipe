using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestManager : MonoBehaviour
{
	public struct Quest001
	{
		public string QuestName;
		public string QuestDiscription;
		public float QuestGoal;
		public Sprite QuestImage;

		public Quest001(string QuestName, string QuestDiscription, float QuestGoal, Sprite QuestImage)
		{
			this.QuestName = QuestName;
			this.QuestDiscription = QuestDiscription;
			this.QuestGoal = QuestGoal;
			this.QuestImage = QuestImage;
		}
	}

	public TextMeshProUGUI QuestNameText;
	public TextMeshProUGUI QuestDiscriptionText;
	public TextMeshProUGUI QuestCountText;

	public List<Quest001> QuestList = new List<Quest001>();

	public float QuestCount;
	public float QuestGoalGlobal;

	void Start()
	{
		SettingQuest();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			AddQuest(Random.Range(0, 101).ToString(), Random.Range(0, 101).ToString(), Random.Range(0, 101), Resources.Load("1") as Sprite);
		}
		if (Input.GetKeyDown(KeyCode.W))
		{
			ResetQuest();
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			QuestCount++;
			QuestCountText.text = QuestCount + " / " + QuestGoalGlobal;
			if (QuestCount >= QuestGoalGlobal)
			{
				Debug.Log("Clear");
			}
		}
	}

	public void SettingQuest()
	{
		AddQuest("호박을 찾아서", "호박", 10, Resources.Load("1") as Sprite);
	}

	public void ResetQuest()
	{
		Quest001 QuestData = QuestList[Random.Range(0, QuestList.Count)];
		QuestNameText.text = QuestData.QuestName;
		QuestDiscriptionText.text = QuestData.QuestDiscription + "을(를) " + QuestData.QuestGoal + "개 가져오기";
		QuestGoalGlobal = QuestData.QuestGoal;
		QuestCountText.text = QuestCount + " / " + QuestGoalGlobal;
	}

	public void AddQuest(string QuestName, string QuestDiscription, float QuestGoal, Sprite QuestImage)
	{
		Quest001 temp = new Quest001();
		temp.QuestName = QuestName;
		temp.QuestDiscription = QuestDiscription;
		temp.QuestGoal = QuestGoal;
		temp.QuestImage = QuestImage;
		QuestList.Add(temp);
	}
}