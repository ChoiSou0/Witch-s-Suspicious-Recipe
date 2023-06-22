using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
	private GameManager GM;
	public SceneAsset scene;
	public float[] warploc = new float[2];
	private bool isonportal;

	private void Start()
	{
		GM = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
		{
			if (isonportal == false)
			{
				GM.isWarped = false;
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			isonportal = true;
			if (GM.isWarped == false)
			{
				GM.Warp(scene.name, warploc);
			}
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			isonportal = false;
			GM.isWarped = false;
		}
	}
}
