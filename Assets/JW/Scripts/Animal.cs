using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum animal_Ani
{
	NONE, IDLE, WALK
}

public class Animal : MonoBehaviour
{
	public bool moveOn;
	private Vector2 startPos;
	private Vector3 endPos;
	public float moveRange;
	public float moveSpeed;
	private bool isreset;
	public float minDelay = 2f;
	public float maxDelay = 5f;

	private Coroutine resetCoroutine;

	[SerializeField] private animal_Ani animal_Ani;
	[SerializeField] private bool Creem = true;
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
		yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
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
				animal_Ani = animal_Ani.IDLE;
				Animation();
			}
			else
			{
				animal_Ani = animal_Ani.WALK;
				Animation();
			}
			transform.localPosition = Vector2.MoveTowards(transform.localPosition, endPos, moveSpeed * Time.deltaTime);
		}
	}

	private void Animation()
	{
		animalAnim.SetBool("IDLE", false);
		animalAnim.SetBool("WALK", false);

		switch (animal_Ani)
		{
			case animal_Ani.IDLE:
				animalAnim.SetBool("IDLE", true);
				break;
			case animal_Ani.WALK:
				animalAnim.SetBool("WALK", true);
				break;
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