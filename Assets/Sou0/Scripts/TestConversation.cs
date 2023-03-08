using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestConversation : NPC
{
    [SerializeField] private Image Conversation_Pnl;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    public override void ActionKey()
    {
        Conversation_Pnl.gameObject.SetActive(true);
    }
    
}
