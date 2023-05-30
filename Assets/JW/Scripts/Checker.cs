using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
	private Magic MG;

	void Start()
	{
		MG = GameObject.Find("Mouse").GetComponent<Magic>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Line")
		{
			MG.activeLine[int.Parse(gameObject.name.Split("Checker")[1])] = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag == "Line")
		{
			MG.activeLine[int.Parse(gameObject.name.Split("Checker")[1])] = false;
		}
	}
}
