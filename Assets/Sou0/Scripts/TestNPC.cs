using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNPC : NPC
{

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
        if (enable)
        {
            Debug.Log("상호작용");
            switch (Type)
            {
                case InteractionType.NONE:
                    Debug.LogError("타입없음");
                    break;
                case InteractionType.SHOP:
                    Debug.Log("상점오픈");
                    break;
            }
        }
    }
}
