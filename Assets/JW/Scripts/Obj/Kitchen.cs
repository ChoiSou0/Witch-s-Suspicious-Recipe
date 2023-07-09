using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitchen : MonoBehaviour
{
	private GameManager GM;

	private void Start()
	{
		GM = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player" && GM.isSeeOpening2 == false)
		{
			GM.isSeeOpening2 = true;
			GM.dialogue.StartDialogue("1Chapter-2");
		}
	}
}
