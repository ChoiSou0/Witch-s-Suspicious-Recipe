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
			rb2D.velocity = Vector3.zero;
		}
		else
		{
			Move();
		}
		StartCoroutine(Test());
		StartCoroutine(Animation());
	}

	IEnumerator Test()
	{
		if (RastVec == 4 || RastVec == 5 || RastVec == 7 || RastVec == 8)
		{
			if (Input.GetKeyUp(KeyCode.W))
			{
				Debug.Log("W");
				if (Input.GetKey(KeyCode.A))
				{
					yield return new WaitForSecondsRealtime(0.5f);
					if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
					{
						Debug.Log("A");
						RastVec = 4;
					}
				}
				else if (Input.GetKey(KeyCode.D))
				{
					yield return new WaitForSecondsRealtime(0.5f);
					if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
					{
						Debug.Log("D");
						RastVec = 7;
					}
				}
			}
			else if (Input.GetKeyUp(KeyCode.A))
			{
				Debug.Log("A");
				if (Input.GetKey(KeyCode.W))
				{
					yield return new WaitForSecondsRealtime(0.5f);
					if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
					{
						Debug.Log("W");
						RastVec = 4;
					}
				}
				if (Input.GetKey(KeyCode.S))
				{
					yield return new WaitForSecondsRealtime(0.5f);
					if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
					{
						Debug.Log("S");
						RastVec = 5;
					}
				}
			}
			else if (Input.GetKeyUp(KeyCode.S))
			{
				Debug.Log("S");
				if (Input.GetKey(KeyCode.A))
				{
					yield return new WaitForSecondsRealtime(0.5f);
					if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
					{
						Debug.Log("A");
						RastVec = 5;
					}
				}
				if (Input.GetKey(KeyCode.D))
				{
					yield return new WaitForSecondsRealtime(0.5f);
					if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
					{
						Debug.Log("D");
						RastVec = 8;
					}
				}
			}
			else if (Input.GetKeyUp(KeyCode.D))
			{
				Debug.Log("D");
				if (Input.GetKey(KeyCode.W))
				{
					yield return new WaitForSecondsRealtime(0.5f);
					if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
					{
						Debug.Log("W");
						RastVec = 7;
					}
				}
				if (Input.GetKey(KeyCode.S))
				{
					yield return new WaitForSecondsRealtime(0.5f);
					if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
					{
						Debug.Log("S");
						RastVec = 8;
					}
				}
			}
		}
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
						spriteRenderer.flipX = true;
						animator.SetBool("isRightIdle", true);
						break;
					case 4:
						spriteRenderer.flipX = true;
						animator.SetBool("isRightUpIdle", true);
						break;
					case 5:
						spriteRenderer.flipX = true;
						animator.SetBool("isRightDownIdle", true);
						break;
					case 6:
						spriteRenderer.flipX = false;
						animator.SetBool("isRightIdle", true);
						break;
					case 7:
						spriteRenderer.flipX = false;
						animator.SetBool("isRightUpIdle", true);
						break;
					case 8:
						spriteRenderer.flipX = false;
						animator.SetBool("isRightDownIdle", true);
						break;

				}
				break;
			case Ani_Type.UP:
				spriteRenderer.flipX = false;
				animator.SetBool("isBehindWalk", true);
				RastVec = 1;
				break;
			case Ani_Type.DOWN:
				spriteRenderer.flipX = false;
				animator.SetBool("isFrontWalk", true);
				RastVec = 2;
				break;
			case Ani_Type.LEFT:
				spriteRenderer.flipX = true;
				animator.SetBool("isRightWalk", true);
				RastVec = 3;
				break;
			case Ani_Type.LEFTUP:
				spriteRenderer.flipX = true;
				animator.SetBool("isRightUpWalk", true);
				RastVec = 4;
				break;
			case Ani_Type.LEFTDOWN:
				spriteRenderer.flipX = true;
				animator.SetBool("isRightDownWalk", true);
				RastVec = 5;
				break;
			case Ani_Type.RIGHT:
				spriteRenderer.flipX = false;
				animator.SetBool("isRightWalk", true);
				RastVec = 6;
				break;
			case Ani_Type.RIGHTUP:
				spriteRenderer.flipX = false;
				animator.SetBool("isRightUpWalk", true);
				RastVec = 7;
				break;
			case Ani_Type.RIGHTDOWN:
				spriteRenderer.flipX = false;
				animator.SetBool("isRightDownWalk", true);
				RastVec = 8;
				break;
			case Ani_Type.PICKUP:
				break;
		}

		yield break;
	}

	// 움직임 함수
	private void Move()
	{
		float MoveX = Input.GetAxisRaw("Horizontal");
		float MoveY = Input.GetAxisRaw("Vertical");

		float X = MoveX * Speed * 2;
		float Y = MoveY * Speed * 2;

		if (MoveX == 0 && MoveY == 0)
			AniType = Ani_Type.IDLE;
		else if (MoveX == 0 && MoveY > 0)
			AniType = Ani_Type.UP;
		else if (MoveX == 0 && MoveY < 0)
			AniType = Ani_Type.DOWN;
		else if (MoveX > 0 && MoveY == 0)
			AniType = Ani_Type.RIGHT;
		else if (MoveX < 0 && MoveY == 0)
			AniType = Ani_Type.LEFT;
		else if (MoveX > 0 && MoveY > 0)
			AniType = Ani_Type.RIGHTUP;
		else if (MoveX > 0 && MoveY < 0)
			AniType = Ani_Type.RIGHTDOWN;
		else if (MoveX < 0 && MoveY > 0)
			AniType = Ani_Type.LEFTUP;
		else if (MoveX < 0 && MoveY < 0)
			AniType = Ani_Type.LEFTDOWN;

		Vector3 GetVel = new Vector3(X, Y, 0);
		rb2D.velocity = GetVel;
	}
}