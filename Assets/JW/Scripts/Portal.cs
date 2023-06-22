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

	private void Start()
	{
		GM = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			GM.Warp(scene.name, warploc);
		}
	}
}
