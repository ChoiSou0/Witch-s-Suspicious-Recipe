using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CollectObj : MonoBehaviour
{
	public int[] Magic = new int[2];
	public string ObjectName;
	private CollectManager CM;

	public bool isActive;

	private int FirstMagic;
	private int SecondMagic;

	void Start()
	{
		CM = GameObject.Find("CollectManager").GetComponent<CollectManager>();
		FirstMagic = Magic[0] - 1;
		SecondMagic = Magic[1] - 1;
	}

	void Update()
	{
		
	}

	public void Collect()
	{
		if (CM.MagicList[FirstMagic] == true)
		{
			if (SecondMagic == -1)
			{
				Debug.Log(GetComponent<CollectObj>().ObjectName + " ä�� ����");
			}
			else if (CM.MagicList[SecondMagic] == true)
			{
				Debug.Log(GetComponent<CollectObj>().ObjectName + " ä�� ����");
			}
			else
			{
				Debug.Log("���� " + GetComponent<CollectObj>().ObjectName + "�� ä���� �� ����");
			}
		}
		else
		{
			Debug.Log("���� " + GetComponent<CollectObj>().ObjectName + "�� ä���� �� ����");
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			//transform.GetChild(0).gameObject.SetActive(true);
			isActive = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			//transform.GetChild(0).gameObject.SetActive(false);
			isActive = false;
		}
	}
}
