using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CreemSheep_Ani
{
    NONE, IDLE, WALK
}

public class CreemSheep_NPC : NPC
{
    [SerializeField] private CreemSheep_Ani CreemSheep_Ani;
    [SerializeField] private Item ItemInfo;
    [SerializeField] private bool Creem = true;
    private Inven_Mgr inven_Mgr;
    private int EmptySlot;
    private Animal Animal;
    private Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
        inven_Mgr = GameObject.FindObjectOfType<Inven_Mgr>();
        Animal = gameObject.GetComponent<Animal>();
        Animator = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Animal.moveOn)
            CreemSheep_Ani = CreemSheep_Ani.WALK;
        else
            CreemSheep_Ani = CreemSheep_Ani.IDLE;

        Animation();
    }

    private void Animation()
    {
        Animator.SetBool("isWalk(Creem)", false);
        Animator.SetBool("isWalk(No)", false);
        Animator.SetBool("isIdle(Creem)", false);

        if (Creem)
        {
            switch (CreemSheep_Ani)
            {
                case CreemSheep_Ani.IDLE:
                    Animator.SetBool("isIdle(Creem)", true);
                    break;
                case CreemSheep_Ani.WALK:
                    Animator.SetBool("isWalk(Creem)", true);
                    break;
            }
        }
        else
        {
            switch (CreemSheep_Ani)
            {
                case CreemSheep_Ani.IDLE:
                    break;
                case CreemSheep_Ani.WALK:
                    Animator.SetBool("isWalk(No)", false);
                    break;
            }
        }
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
