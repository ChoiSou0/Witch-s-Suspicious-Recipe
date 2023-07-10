using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public enum Ani_Type
{
	IDLE, UP, DOWN, LEFT, RIGHT, RIGHTUP,
	RIGHTDOWN, LEFTUP, LEFTDOWN, PICKUP
}

public class Player : MonoBehaviour
{
	[SerializeField] private Ani_Type AniType;
	[SerializeField] private int RastVec = 1;
	public float Speed;
	private float MaxSpeed;
	public bool DontMove;

	private Rigidbody2D rb2D;
	private Animator animator;
	private SpriteRenderer spriteRenderer;
	private GameObject NowNPC;

	private void Awake()
	{
		rb2D = this.GetComponent<Rigidbody2D>();
		animator = this.GetComponentInChildren<Animator>();
		spriteRenderer = this.GetComponentInChildren<SpriteRenderer>();
	}

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (DontMove == true)
		{
			rb2D.velocity = new Vector3(0, 0, 0);
		}
		else
		{
			Move();
		}
		StartCoroutine(Animation());
	}

	IEnumerator Animation()
	{
		animator.SetBool("isFrontIdle", false);
		animator.SetBool("isFrontWalk", false);
		animator.SetBool("isBehindIdle", false);
		animator.SetBool("isBehindWalk", false);
		animator.SetBool("isRightIdle", false);
		animator.SetBool("isRightWalk", false);
		animator.SetBool("isRightUpIdle", false);
		animator.SetBool("isRightUpWalk", false);
		animator.SetBool("isRightDownIdle", false);
		animator.SetBool("isRightDownWalk", false);

		switch (AniType)
		{
			case Ani_Type.IDLE:
				//Debug.Log(RastVec);
				switch (RastVec)
				{
					case 1:
						spriteRenderer.flipX = false;
						animator.SetBool("isBehindIdle", true);
						break;
					case 2:
						spriteRenderer.flipX = false;
						animator.SetBool("isFrontIdle", true);
						break;
					case 3:
						spriteRenderer.flipX = false;
						animator.SetBool("isRightIdle", true);
						break;
					case 4:
						spriteRenderer.flipX = false;
						animator.SetBool("isRightUpIdle", true);
						Debug.Log("asd");
						break;
					case 5:
						spriteRenderer.flipX = false;
						animator.SetBool("isRightDownIdle", true);
						Debug.Log("asd");
						break;
					case 6:
						spriteRenderer.flipX = true;
						animator.SetBool("isRightIdle", true);
						break;
					case 7:
						spriteRenderer.flipX = true;
						animator.SetBool("isRightUpIdle", true);
						Debug.Log("asd");
						break;
					case 8:
						spriteRenderer.flipX = true;
						animator.SetBool("isRightDownIdle", true);
						Debug.Log("asd");
						break;
				}
				break;
			case Ani_Type.UP:
				spriteRenderer.flipX = false;
				animator.SetBool("isBehindWalk", true);
				yield return new WaitForSecondsRealtime(0.1f);
				break;
			case Ani_Type.DOWN:
				spriteRenderer.flipX = false;
				animator.SetBool("isFrontWalk", true);
				yield return new WaitForSecondsRealtime(0.1f);
				break;
			case Ani_Type.RIGHT:
				spriteRenderer.flipX = false;
				animator.SetBool("isRightWalk", true);
				yield return new WaitForSecondsRealtime(0.1f);
				break;
			case Ani_Type.RIGHTUP:
				spriteRenderer.flipX = false;
				animator.SetBool("isRightUpWalk", true);
				yield return new WaitForSecondsRealtime(0.1f);
				break;
			case Ani_Type.RIGHTDOWN:
				spriteRenderer.flipX = false;
				animator.SetBool("isRightDownWalk", true);
				yield return new WaitForSecondsRealtime(0.1f);
				break;
			case Ani_Type.LEFT:
				spriteRenderer.flipX = true;
				animator.SetBool("isRightWalk", true);
				yield return new WaitForSecondsRealtime(0.1f);
				break;
			case Ani_Type.LEFTUP:
				spriteRenderer.flipX = true;
				animator.SetBool("isRightUpWalk", true);
				yield return new WaitForSecondsRealtime(0.1f);
				break;
			case Ani_Type.LEFTDOWN:
				spriteRenderer.flipX = true;
				animator.SetBool("isRightDownWalk", true);
				yield return new WaitForSecondsRealtime(0.1f);
				break;
			case Ani_Type.PICKUP:
				break;
		}

		yield break;
	}

	// 움직임 함수
	private void Move()
	{
		float MoveX = Input.GetAxis("Horizontal");
		float MoveY = Input.GetAxis("Vertical");

		if(MoveX!=0 && MoveY != 0)
		{
			Debug.Log(MoveX);
			Debug.Log(MoveY);
		}

		float X = MoveX * Speed * 2;
		float Y = MoveY * Speed * 2;

		if (MoveX == 0 && MoveY == 0)
			AniType = Ani_Type.IDLE;
		else if (MoveX == 0 && MoveY > 0)
		{
			AniType = Ani_Type.UP;
			RastVec = 1;
		}
		else if (MoveX == 0 && MoveY < 0)
		{
			AniType = Ani_Type.DOWN;
			RastVec = 2;
		}
		else if (MoveX > 0 && MoveY == 0)
		{
			AniType = Ani_Type.RIGHT;
			RastVec = 3;
		}

		else if (MoveX > 0 && MoveY > 0)
		{
			AniType = Ani_Type.RIGHTUP;
			RastVec = 4;
		}
		else if (MoveX > 0 && MoveY < 0)
		{
			AniType = Ani_Type.RIGHTDOWN;
			RastVec = 5;
		}
		else if (MoveX < 0 && MoveY == 0)
		{
			AniType = Ani_Type.LEFT;
			RastVec = 6;
		}
		else if (MoveX < 0 && MoveY > 0)
		{
			AniType = Ani_Type.LEFTUP;
			RastVec = 7;
		}
		else if (MoveX < 0 && MoveY < 0)
		{
			AniType = Ani_Type.LEFTDOWN;
			RastVec = 8;
		}

		Vector3 GetVel = new Vector3(X, Y, 0);
		rb2D.velocity = GetVel;


	}
}