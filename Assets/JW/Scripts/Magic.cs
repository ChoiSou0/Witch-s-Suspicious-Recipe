using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Magic : MonoBehaviour
{
	[HideInInspector] public bool isEnterNode;
	[HideInInspector] public bool isComplete;
	[HideInInspector] public bool isReset;
	[HideInInspector] public bool isStart;
	private bool[] alreadyUsed = new bool[9];
	public bool[] activeLine = new bool[28];
	[HideInInspector] public int[] activeNum = new int[9];
	private int otherNum;
	private int prevNum;
	public Collider2D otherObj;

	void Update()
	{
		transform.position = Input.mousePosition;

		if (Input.GetKeyDown(KeyCode.E) && !Input.GetMouseButton(0))
		{
			if (activeNum[1] != 0 && isComplete == false)
			{
				MagicComplete();
			}
		}
	}

	public void ResetMagic()
	{
		for (int i = 0; i < 9; i++)
		{
			activeNum[i] = 0;
			alreadyUsed[i] = false;
			GameObject.Find("Node" + i).GetComponent<Image>().color = new Color(1, 1, 1);
		}
		isComplete = false;
		isReset = true;
		isStart = false;
		isEnterNode = false;
		otherObj = null;
	}

	private void Through(int i, int num)
	{
		alreadyUsed[num] = true;
		activeNum[i + 1] = activeNum[i];
		activeNum[i] = num + 1;
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		/*if (collision.tag == "Complete")
		{
			if (activeNum[1] != 0 && isComplete == false)
			{
				MagicComplete();
			}
		}*/
		if (collision.tag == "Node")
		{
			if (Input.GetMouseButton(0))
			{
				if (isStart == false)
				{
					int Num = int.Parse(collision.name.Split("Node")[1]);
					alreadyUsed[Num] = true;
					for (int i = 0; i < 9; i++)
					{
						if (activeNum[i] == 0)
						{
							activeNum[i] = Num + 1;
							GameObject.Find("Node" + Num).GetComponent<Image>().color = new Color(0, 1, 0);
							break;
						}
					}
					LineCreator temp = Instantiate(Resources.Load<GameObject>("Prefeb/Line"), transform.position, Quaternion.identity, GameObject.Find("MagicCanvas").transform).GetComponent<LineCreator>();
					temp.pointA = collision.transform.position;
					isReset = false;
					isStart = true;
					prevNum = Num;
				}
				otherNum = int.Parse(collision.name.Split("Node")[1]);
				if (alreadyUsed[otherNum] == false)
				{
					alreadyUsed[otherNum] = true;
					for (int i = 0; i < 9; i++)
					{
						//한칸 건너뛰고 그린거 처리
						if (activeNum[i] == 0)
						{
							activeNum[i] = otherNum + 1;
							GameObject.Find("Node" + otherNum).GetComponent<Image>().color = new Color(0, 1, 0);
							if (prevNum == 0 && otherNum == 2 && alreadyUsed[1] != true)
							{
								Through(i, 1);
								i += 1;
								GameObject.Find("Node" + 1).GetComponent<Image>().color = new Color(0, 1, 0);
							}
							else if (prevNum == 0 && otherNum == 6 && alreadyUsed[3] != true)
							{
								Through(i, 3);
								i += 1;
								GameObject.Find("Node" + 3).GetComponent<Image>().color = new Color(0, 1, 0);
							}
							else if (prevNum == 0 && otherNum == 8 && alreadyUsed[4] != true)
							{
								Through(i, 4);
								i += 1;
								GameObject.Find("Node" + 4).GetComponent<Image>().color = new Color(0, 1, 0);
							}
							else if (prevNum == 1 && otherNum == 7 && alreadyUsed[4] != true)
							{
								Through(i, 4);
								i += 1;
								GameObject.Find("Node" + 4).GetComponent<Image>().color = new Color(0, 1, 0);
							}
							else if (prevNum == 2 && otherNum == 0 && alreadyUsed[1] != true)
							{
								Through(i, 1);
								i += 1;
								GameObject.Find("Node" + 1).GetComponent<Image>().color = new Color(0, 1, 0);
							}
							else if (prevNum == 2 && otherNum == 6 && alreadyUsed[4] != true)
							{
								Through(i, 4);
								i += 1;
								GameObject.Find("Node" + 4).GetComponent<Image>().color = new Color(0, 1, 0);
							}
							else if (prevNum == 2 && otherNum == 8 && alreadyUsed[5] != true)
							{
								Through(i, 5);
								i += 1;
								GameObject.Find("Node" + 5).GetComponent<Image>().color = new Color(0, 1, 0);
							}
							else if (prevNum == 3 && otherNum == 5 && alreadyUsed[4] != true)
							{
								Through(i, 4);
								i += 1;
								GameObject.Find("Node" + 4).GetComponent<Image>().color = new Color(0, 1, 0);
							}
							else if (prevNum == 5 && otherNum == 3 && alreadyUsed[4] != true)
							{
								Through(i, 4);
								i += 1;
								GameObject.Find("Node" + 4).GetComponent<Image>().color = new Color(0, 1, 0);
							}
							else if (prevNum == 6 && otherNum == 0 && alreadyUsed[3] != true)
							{
								Through(i, 3);
								i += 1;
								GameObject.Find("Node" + 3).GetComponent<Image>().color = new Color(0, 1, 0);
							}
							else if (prevNum == 6 && otherNum == 2 && alreadyUsed[4] != true)
							{
								Through(i, 4);
								i += 1;
								GameObject.Find("Node" + 4).GetComponent<Image>().color = new Color(0, 1, 0);
							}
							else if (prevNum == 6 && otherNum == 8 && alreadyUsed[7] != true)
							{
								Through(i, 7);
								i += 1;
								GameObject.Find("Node" + 7).GetComponent<Image>().color = new Color(0, 1, 0);
							}
							else if (prevNum == 7 && otherNum == 1 && alreadyUsed[4] != true)
							{
								Through(i, 4);
								i += 1;
								GameObject.Find("Node" + 4).GetComponent<Image>().color = new Color(0, 1, 0);
							}
							else if (prevNum == 8 && otherNum == 0 && alreadyUsed[4] != true)
							{
								Through(i, 4);
								i += 1;
								GameObject.Find("Node" + 4).GetComponent<Image>().color = new Color(0, 1, 0);
							}
							else if (prevNum == 8 && otherNum == 2 && alreadyUsed[5] != true)
							{
								Through(i, 5);
								i += 1;
								GameObject.Find("Node" + 5).GetComponent<Image>().color = new Color(0, 1, 0);
							}
							else if (prevNum == 8 && otherNum == 6 && alreadyUsed[7] != true)
							{
								Through(i, 7);
								i += 1;
								GameObject.Find("Node" + 7).GetComponent<Image>().color = new Color(0, 1, 0);
							}
							prevNum = otherNum;
							if (i == 8)
							{
								Invoke("MagicComplete", 0.1f);
							}
							break;
						}
					}
					otherObj = collision;
					isEnterNode = true;
				}
			}
		}
	}

	private void MagicComplete()
	{
		for (int i = 0; i < 9; i++)
		{
			if (activeNum[i] == 0)
			{
				activeNum[i] = 99;
			}
			alreadyUsed[i] = true;
			GameObject.Find("Node" + i).GetComponent<Image>().color = new Color(0, 1, 0);
		}
		isComplete = true;

		CheckShape(new int[] { 0, 10, 8, 19, 21, 23 }, "뱀");
		CheckShape(new int[] { 2, 22, 23, 27, 15, 12 }, "마늘");
		CheckShape(new int[] { 11, 17, 21, 23, 27 }, "크림");

		//CheckShape(new int[] { 0, 10, 6, 15, 12, 17, 21, 23 }, "ㄹ");
		//CheckShape(new int[] { 12, 15 }, "a");


		//CheckShape(new int[] { 1, 2, 3, 6, 5, 4, 7, 8, 9 }, 9, "ㄹ");
		//CheckShape(new int[] { 5, 6, 3, 2, 1, 4, 7, 8, 9 }, 9, "e");
		//CheckShape(new int[] { 1, 4, 7, 8, 9, 6, 3 }, 7, "U");
		//CheckShape(new int[] { 3, 2, 1, 4, 7, 8, 9 }, 7, "ㄷ");
		//CheckShape(new int[] { 7, 4, 1, 5, 3, 6, 9 }, 7, "M");
		//CheckShape(new int[] { 7, 4, 1, 5, 9, 6, 3 }, 7, "N");
		//CheckShape(new int[] { 1, 2, 3, 5, 7, 8, 9 }, 7, "Z");
		//CheckShape(new int[] { 2, 4, 5, 6, 8 }, 5, "⚡");
		//CheckShape(new int[] { 1, 2, 3, 6, 9 }, 5, "ㄱ");
		//CheckShape(new int[] { 1, 4, 7, 8, 9 }, 5, "ㄴ");
		//CheckShape(new int[] { 3, 2, 4, 5, 6, 8, 7 }, 7, "S");
	}

	private void CheckShape(int[] shape, string printText)
	{
		int counter = 0;
		int correctNum = 0;
		int reachNum = shape.Length;
		bool fail = false;

		foreach (bool i in activeLine)
		{
			if (activeLine[counter] == true)
			{
				if (shape.Contains(counter))
				{
					//Debug.Log(counter + " O");
					correctNum++;
				}
				else
				{
					//Debug.Log(counter + " X");
					fail = true;
				}
			}
			/*else
			{
				Debug.Log(counter + " N");
			}*/
			counter++;
		}
		if (correctNum == reachNum && fail == false)
		{
			Debug.Log(printText);
		}
		//Debug.Log(counter);
		//Debug.Log(correctNum);
		//Debug.Log(reachNum);
		//Debug.Log(fail);
	}
}
