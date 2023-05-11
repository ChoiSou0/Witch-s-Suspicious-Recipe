using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public enum Ani_Type
{
	IDLE, UP, DOWN, LEFT, RIGHT, RIGHTUP,
	RIGHTDOWN, LEFTUP, LEFTDOWN,
}

public class Player : MonoBehaviour
{
	[SerializeField] private Ani_Type AniType;
	public float Speed;
	private float MaxSpeed;

	private Rigidbody2D rb2D;
	private Animator animator;
	private GameObject NowNPC;

	private void Awake()
	{
		rb2D = this.GetComponent<Rigidbody2D>();
		animator = this.GetComponent<Animator>();
	}

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		Move();
		Animation();
	}

	private void Animation()
	{
		switch (AniType)
		{
			case Ani_Type.IDLE:
				break;
			case Ani_Type.UP:
				break;
			case Ani_Type.DOWN:
				break;
			case Ani_Type.RIGHT:
				break;
			case Ani_Type.RIGHTUP:
				break;
			case Ani_Type.RIGHTDOWN:
				break;
			case Ani_Type.LEFTUP:
				break;
			case Ani_Type.LEFTDOWN:
				break;
		}
	}

	// 움직임 함수
	private void Move()
	{
		float MoveX = Input.GetAxis("Horizontal");
		float MoveY = Input.GetAxis("Vertical");

		float X = MoveX * Speed * 2;
		float Y = MoveY * Speed * 2;

		Vector3 GetVel = new Vector3(X, Y, 0);
		rb2D.velocity = GetVel;

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
	}
}