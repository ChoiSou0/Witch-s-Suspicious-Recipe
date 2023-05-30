using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraManager : MonoBehaviour
{
	void Start()
	{

	}

	void Update()
	{
		Debug.Log(transform.position);
		Debug.Log(transform.localPosition);
		if (gameObject.transform.parent.transform.position.x < -10)
		{
			transform.position = new Vector3(-10, transform.position.y, -10);
		}
		else if (gameObject.transform.parent.transform.position.x > 10)
		{
			transform.position = new Vector3(10, transform.position.y, -10);
		}
		else
		{
			transform.localPosition = new Vector3(0, transform.localPosition.y, -10);
		}

		if (gameObject.transform.parent.transform.position.y < -5)
		{
			transform.position = new Vector3(transform.position.x, -5, -10);
		}
		else if (gameObject.transform.parent.transform.position.y > 5)
		{
			transform.position = new Vector3(transform.position.x, 5, -10);
		}
		else
		{
			transform.localPosition = new Vector3(transform.localPosition.x, 0, -10);
		}
	}
}
