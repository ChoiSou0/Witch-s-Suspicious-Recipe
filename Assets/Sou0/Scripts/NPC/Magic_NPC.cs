using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magic_NPC : NPC
{
	void Update()
	{
		base.Update();
	}

	public override void ActionKey()
	{
		gameObject.transform.GetChild(0).gameObject.SetActive(true);
		//Inven_Pnl.gameObject.SetActive(true);
	}

	public void OnCancelBtn()
	{
		gameObject.transform.GetChild(0).gameObject.SetActive(false);
		//Inven_Pnl.gameObject.SetActive(false);
	}

}
