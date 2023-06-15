using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
	GameObject closest;

	void Start()
	{

	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			try
			{
				if (closest.GetComponent<CollectObj>().isActive == true)
				{
					closest.GetComponent<CollectObj>().Collect();
				}
			}
			catch { }
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		try
		{
			closest.transform.GetChild(0).gameObject.SetActive(false);
		}
		catch { }
		FindClosestObject();
		closest.transform.GetChild(0).gameObject.SetActive(true);
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		closest.transform.GetChild(0).gameObject.SetActive(false);
	}

	public GameObject FindClosestObject()
	{
		GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Line");
		GameObject closestObject = null;
		float closestDistance = Mathf.Infinity;
		Vector3 currentPosition = transform.position;

		foreach (GameObject obj in objectsWithTag)
		{
			float distance = Vector3.Distance(obj.transform.position, currentPosition);
			if (distance < closestDistance)
			{
				closestDistance = distance;
				closestObject = obj;
			}
		}

		closest = closestObject;
		return null;
	}
}
