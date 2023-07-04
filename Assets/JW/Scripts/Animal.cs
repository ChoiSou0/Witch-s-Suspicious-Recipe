using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
	public bool moveOn;
	private Vector2 startPos;
	private Vector3 endPos;
	public float moveRange;
	public float moveSpeed;
	private bool isreset;

	private Coroutine resetCoroutine;

	public Animator animalAnim;

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
		yield return new WaitForSeconds(Random.Range(2f, 5f));
		ResetPos();
		isreset = true;
	}

	private void ResetPos()
	{
		endPos = new Vector2(Random.Range(-moveRange, moveRange), Random.Range(-moveRange, moveRange));
	}

	private void Move()
	{
		if (moveOn)
		{
			if (transform.localPosition == endPos)
			{
				if (isreset == true)
				{
					isreset = false;
					StartCoroutine(ResetCoroutine());
				}
				animalAnim.SetInteger("state", 0);
			}
			else
			{
				animalAnim.SetInteger("state", 1);
			}
			transform.localPosition = Vector2.MoveTowards(transform.localPosition, endPos, moveSpeed * Time.deltaTime);
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