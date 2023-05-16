using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
	public bool moveOn;
	private Vector2 startPos;
	private Vector2 endPos;
	public float moveRange;
	public float moveSpeed;

	void Start()
	{
		moveOn = true;
		startPos = transform.localPosition;
		InvokeRepeating("ResetPos", 0f, 3f);
	}

	void Update()
	{
		Move();
	}

	public void ResetPos()
	{
		endPos = new Vector2(Random.Range(-moveRange, moveRange), Random.Range(-moveRange, moveRange));
	}

	private void Move()
	{
		if (moveOn)
		{
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, endPos, moveSpeed * 10 * Time.deltaTime);
		}
	}

#if UNITY_EDITOR
	private void OnDrawGizmos()
	{
		UnityEditor.Handles.color = Color.green;
		UnityEditor.Handles.DrawWireCube(transform.position, new Vector3(moveRange * 2, moveRange * 2, 0));
	}
#endif
}
