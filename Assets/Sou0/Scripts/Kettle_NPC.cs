using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kettle_NPC : NPC
{
    [SerializeField] private Image Conversation_Pnl;
    [SerializeField] private Image Inven_Pnl;
    
    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    public override void ActionKey()
    {
        Conversation_Pnl.gameObject.SetActive(true);
        Inven_Pnl.gameObject.SetActive(true);
    }

    public void OnCancelBtn()
    {
        Conversation_Pnl.gameObject.SetActive(false);
        Inven_Pnl.gameObject.SetActive(false);
    }
    
}
