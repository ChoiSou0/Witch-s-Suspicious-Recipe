using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class YarnScript : MonoBehaviour
{
	public SoundManager soundManager;

	[YarnCommand("test")]
	public static void Test()
	{
		Debug.Log("s");
	}

	[YarnCommand("playSE")]
	public void PlaySE()
	{
		Debug.Log("d");
		soundManager.PlaySE(Resources.Load<AudioClip>("Clip/MP_Pew Pew"));
	}
}
