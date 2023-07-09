using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreemSheep_NPC : NPC
{
    [SerializeField] private Item ItemInfo;
    [SerializeField] private bool Creem = true;
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

    }

    public override void ActionKey()
    {
        for (int i = 0; i < inven_Mgr.slot.Count; i++)
        {
            if ((inven_Mgr.slot[i].Count == 0 || inven_Mgr.slot[i].Count < inven_Mgr.slot[i].MaxCount)
                && (ItemInfo == inven_Mgr.slot[i].ItemInfo || inven_Mgr.slot[i].ItemInfo == null))
            {
                EmptySlot = i;
                break;
            }

        }

        inven_Mgr.slot[EmptySlot].ItemInfo = this.ItemInfo;
        inven_Mgr.slot[EmptySlot].MaxCount = this.ItemInfo.InvenMaxCount;
        inven_Mgr.slot[EmptySlot].Count++;
        inven_Mgr.slot[EmptySlot].Name = this.ItemInfo.ItemName;
        inven_Mgr.slot[EmptySlot].ItemImage.sprite = this.ItemInfo.ItemImage;
        Creem = false;
    }

}
