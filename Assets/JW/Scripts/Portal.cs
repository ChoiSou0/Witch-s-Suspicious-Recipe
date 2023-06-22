using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
	private GameManager GM;
	public SceneAsset scene;
	public bool isOnPortal;
	public float[] warploc = new float[2];

	private void Start()
	{
		GM = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			if (isOnPortal == true)
			{
				GM.isPortalDisable = true;
			}
			if (GM.isPortalDisable == false)
			{
				GM.Warp(scene.name, warploc);
			}
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			GM.isPortalDisable = false;
		}
	}
}
