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
	[SerializeField] private bool Cream = true;
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
		Debug.Log(Cream);
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
		if (true) //캐릭터 구분할 조건문 넣기
		{
			animalAnim.SetBool("isIdle(Cream)", false);
			animalAnim.SetBool("isWalk(Cream)", false);
			animalAnim.SetBool("isWalk(No)", false);
			switch (animal_Ani)
			{
				case animal_Ani.IDLE:
					animalAnim.SetBool("isIdle(Cream)", true);
					break;
				case animal_Ani.WALK:
					if (Cream)
					{
						animalAnim.SetBool("isWalk(Cream)", true);
					}
					else
					{
						animalAnim.SetBool("isWalk(No)", true);
					}
					break;
			}
		}
		else if (true) //캐릭터 추가하기
		{
			animalAnim.SetBool("isIdle", false);
			animalAnim.SetBool("isWalk", false);
			switch (animal_Ani)
			{
				case animal_Ani.IDLE:
					animalAnim.SetBool("isIdle", true);
					break;
				case animal_Ani.WALK:
					animalAnim.SetBool("isWalk", true);
					break;
			}
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