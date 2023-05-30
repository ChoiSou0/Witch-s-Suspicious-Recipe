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

	private Coroutine resetCoroutine;

	void Start()
	{
		moveOn = true;
		startPos = transform.localPosition;
		resetCoroutine = StartCoroutine(ResetCoroutine());
	}

	void Update()
	{
		Move();
	}

	IEnumerator ResetCoroutine()
	{
		while (true)
		{
			ResetPos();
			yield return new WaitForSeconds(3f);
		}
	}

	private void ResetPos()
	{
		endPos = new Vector2(Random.Range(-moveRange, moveRange), Random.Range(-moveRange, moveRange));
	}

	private void Move()
	{
		if (moveOn)
		{
			transform.localPosition = Vector2.MoveTowards(transform.localPosition, endPos, moveSpeed * 10 * Time.deltaTime);
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