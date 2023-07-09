using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Test : MonoBehaviour
{
	public DialogueRunner test;

	void Start()
	{

	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.G))
		{
			test.StartDialogue("Test");
		}
	}
}
