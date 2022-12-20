using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Need
{
    public Item NeedItem;
    public int NeedCount;
}

public class Conversation : MonoBehaviour
{
    [SerializeField] private List<Need> NeedItems = new List<Need>();
    private Inven_Mgr inven_Mgr;
    private Button thisBtn;

    private int CombinationCondition;

    private void Awake()
    {
        inven_Mgr = GameObject.FindObjectOfType<Inven_Mgr>();
        thisBtn = this.GetComponent<Button>();
        thisBtn.onClick.AddListener(ClickConversation);
    }
    
    private void ClickConversation()
    {
        for (int i = 0; i < NeedItems.Count; i++)
        {
            //Debug.Log(inven_Mgr.FindSlot(NeedItems[i].NeedItem, NeedItems[i].NeedCount) != 0);
            if (inven_Mgr.FindSlot(NeedItems[i].NeedItem, NeedItems[i].NeedCount) != 0)
                CombinationCondition++;
        }

        Debug.Log(CombinationCondition); 

        if (CombinationCondition == NeedItems.Count)
        {
            Debug.Log("조합성공");
        }
        else
        {
            Debug.Log("조합실패");
        }

        CombinationCondition = 0;
    }
}
