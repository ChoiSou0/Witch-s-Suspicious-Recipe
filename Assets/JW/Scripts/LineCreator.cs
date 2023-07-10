using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator : MonoBehaviour
{
	private RectTransform imageRectTransform;
	private BoxCollider2D imageCollider;
	public float lineWidth = 1.0f;
	public Vector3 pointA;
	public Vector3 pointB;

	public bool stopLoop;

	private Magic MG;

	void Start()
	{
		imageRectTransform = GetComponent<RectTransform>();
		imageCollider = GetComponent<BoxCollider2D>();
		MG = GameObject.Find("Mouse").GetComponent<Magic>();
	}

	void Update()
	{
		if (!stopLoop)
		{
			pointB = Input.mousePosition;
			if (Input.GetMouseButtonUp(0))
			{
				if (MG.otherObj != null)
				{
					pointB = MG.otherObj.transform.position;
				}
				else
				{
					pointB = pointA;
				}
				LineDraw();
			}
			else if (MG.isComplete)
			{
				stopLoop = true;
				pointB = MG.otherObj.transform.position;
			}
			else if (MG.isEnterNode)
			{
				MG.isEnterNode = false;
				stopLoop = true;
				pointB = MG.otherObj.transform.position;
				LineCreator Insobj = Instantiate(Resources.Load<GameObject>("Prefab/Line"), transform.position, Quaternion.identity, GameObject.Find("MagicCanvas").transform).GetComponent<LineCreator>();
				Insobj.pointA = MG.otherObj.transform.position;
			}
		}
		if (MG.isReset)
		{
			Destroy(gameObject);
		}
		if (Input.GetMouseButton(0))
		{
			LineDraw();
		}
	}

	private void LineDraw()
	{
		Vector3 differenceVector = pointB - pointA;

		imageRectTransform.sizeDelta = new Vector2(differenceVector.magnitude, lineWidth);
		imageCollider.offset = new Vector2(differenceVector.magnitude / 2, 0);
		imageCollider.size = new Vector2(differenceVector.magnitude, lineWidth);
		imageRectTransform.pivot = new Vector2(0, 0.5f);
		imageRectTransform.position = pointA;
		float angle = Mathf.Atan2(differenceVector.y, differenceVector.x) * Mathf.Rad2Deg;
		imageRectTransform.rotation = Quaternion.Euler(0, 0, angle);
	}
}