using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ConversationType
{
    OVEN, KETTLE
}

[System.Serializable]
public class Need
{
    public Item NeedItem;
    public int NeedCount;
}

public class Conversation : MonoBehaviour
{
    [SerializeField] private List<Need> NeedItems = new List<Need>();
    [SerializeField] private Item ConversationItem;
    [SerializeField] private ConversationType ConversationType;
    private Inven_Mgr inven_Mgr;
    private Button thisBtn;

    private int CombinationCondition;

    private void Awake()
    {
        inven_Mgr = GameObject.FindObjectOfType<Inven_Mgr>();
        thisBtn = this.GetComponent<Button>();
        thisBtn.onClick.AddListener(ClickConversation);
    }
    
    // 클릭할 시에 아이템 조합이 이루어 지는 함수
    private void ClickConversation()
    {
        int Compare = 0;
        List<int> SlotNum = new List<int>();

        // 밑에 for문에 문제가 있어서 다른 방식으로 해결은 했지만
        // 그 방법이 문제가 있으면 수정이 필요함
        for (int i = 0; i < NeedItems.Count; i++)
        {
            Compare = inven_Mgr.FindSlot(NeedItems[i].NeedItem, NeedItems[i].NeedCount);

            if (Compare >= 0)
            {
                SlotNum.Add(Compare);
                CombinationCondition++;
            }
        }

        // 밑에 조합 관련 부분 수정
        if (CombinationCondition == NeedItems.Count)
        {
            for (int i = 0; i < NeedItems.Count; i++)
            {
                inven_Mgr.slot[SlotNum[i]].Count -= NeedItems[i].NeedCount;
            }

            for (int i = 0; i < inven_Mgr.slot.Count; i++)
            {
                if ((inven_Mgr.slot[i].Count == 0 || inven_Mgr.slot[i].Count < inven_Mgr.slot[i].MaxCount)
                    && (ConversationItem == inven_Mgr.slot[i].ItemInfo || inven_Mgr.slot[i].ItemInfo == null))
                {
                    inven_Mgr.slot[i].ItemInfo = this.ConversationItem;
                    inven_Mgr.slot[i].MaxCount = this.ConversationItem.InvenMaxCount;
                    inven_Mgr.slot[i].Count++;
                }

            }

            Debug.Log("조합성공");
        }
        else
        {
            Debug.Log("조합실패");
        }

        CombinationCondition = 0;
    }
}
