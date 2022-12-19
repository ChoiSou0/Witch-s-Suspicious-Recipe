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
        Destroy(this.gameObject);

    }

}
