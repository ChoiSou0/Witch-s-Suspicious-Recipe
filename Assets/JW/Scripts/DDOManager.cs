using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DDOManager : MonoBehaviour
{
	public SceneAsset startScene;
	public GameObject[] objectList;

	void Start()
	{
		for (int i = 0; i < objectList.Length; i++)
		{
			DontDestroyOnLoad(objectList[i]);
		}
		SceneManager.LoadScene(startScene.name);
	}

	void Update()
	{

	}
}
