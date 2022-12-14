using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestItem : NPC
{
    [SerializeField] private Item ItemInfo;
    private Inven_Mgr inven_Mgr;
    private int EmptySlot;

    // Start is called before the first frame update
    void Start()
    {
        inven_Mgr = GameObject.FindObjectOfType<Inven_Mgr>();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    public override void ActionKey()
    {
        for(int i = 0; i < inven_Mgr.slot.Count; i++)
        {

        }
    }

}
