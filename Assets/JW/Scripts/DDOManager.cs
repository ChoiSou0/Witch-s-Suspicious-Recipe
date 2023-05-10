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
			//objectList[i].AddComponent<DDOObj>();
			DontDestroyOnLoad(objectList[i]);
		}
		if (startScene != null)
		{
			SceneManager.LoadScene(startScene.name);
		}
		Destroy(this.gameObject);
	}

	void Update()
	{

	}
}
