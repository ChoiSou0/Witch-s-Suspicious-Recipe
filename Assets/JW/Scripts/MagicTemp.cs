using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MagicTemp : MonoBehaviour
{
	[HideInInspector] public bool isEnterNode;
	private bool[] alreadyUsed = new bool[9];
	private int otherNum;
	private bool isStart;
	[HideInInspector] public Collider2D otherObj;

	void Start()
	{

	}

	void Update()
	{
		transform.position = Input.mousePosition;
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (Input.GetMouseButton(0))
		{
			if (isStart == false)
			{
				alreadyUsed[int.Parse(collision.name.Split("Button (")[1].Split(")")[0])] = true;
				LineCreator temp = Instantiate(Resources.Load("Prefeb/Line") as GameObject, transform.position, Quaternion.identity, GameObject.Find("Canvas").transform).GetComponent<LineCreator>();
				temp.pointA = collision.transform.position;
				isStart = true;
			}
			otherNum = int.Parse(collision.name.Split("Button (")[1].Split(")")[0]);
			if (alreadyUsed[otherNum] == false)
			{
				alreadyUsed[otherNum] = true;
				otherObj = collision;
				isEnterNode = true;
			}
		}
	}
}
