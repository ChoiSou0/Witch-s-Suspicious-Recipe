using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator : MonoBehaviour
{
	private RectTransform imageRectTransform;
	public float lineWidth = 1.0f;
	public Vector3 pointA;
	public Vector3 pointB;

	public bool stoploop;

	private MagicTemp MG;

	void Start()
	{
		imageRectTransform = GetComponent<RectTransform>();
		MG = GameObject.Find("Checker").GetComponent<MagicTemp>();
	}

	void Update()
	{
		if (stoploop == false)
		{
			pointB = Input.mousePosition;
		}
		if (MG.isComplete == true && stoploop == false)
		{
			stoploop = true;
			pointB = MG.otherObj.transform.position;
		}
		if (MG.isEnterNode == true && stoploop == false)
		{
			MG.isEnterNode = false;
			stoploop = true;
			pointB = MG.otherObj.transform.position;
			LineCreator temp = Instantiate(Resources.Load("Prefeb/Line") as GameObject, transform.position, Quaternion.identity, GameObject.Find("Canvas").transform).GetComponent<LineCreator>();
			temp.pointA = MG.otherObj.transform.position;
		}
		if (Input.GetMouseButton(0))
		{
			Vector3 differenceVector = pointB - pointA;

			imageRectTransform.sizeDelta = new Vector2(differenceVector.magnitude, lineWidth);
			imageRectTransform.pivot = new Vector2(0, 0.5f);
			imageRectTransform.position = pointA;
			float angle = Mathf.Atan2(differenceVector.y, differenceVector.x) * Mathf.Rad2Deg;
			imageRectTransform.rotation = Quaternion.Euler(0, 0, angle);
		}
	}
}
