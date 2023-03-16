using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inven_Mgr : MonoBehaviour
{
    [SerializeField] private Image Inven;
    public List<Slot> slot = new List<Slot>();
    public int MaxSlot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OpenCloseInven();
    }

    // 인벤토리가 열러 있고 닫혀 있음에 따라 다른 함수
    public void OpenCloseInven()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (Inven.gameObject.activeSelf)
                Inven.gameObject.SetActive(false);
            else if (!Inven.gameObject.activeSelf)
            {
                Inven.gameObject.SetActive(true);
            }
        }
    }

    // 해당 아이템을 찾아서 인트형으로 반환해주는 함수
    // 일단은 조합코드에 문제로 +1로 1이 더해져서 나오는 방식이라서
    // 추후에 수정해야 될 수도 있음
    public int FindSlot(Item NeedItem, int NeedCount)
    {
        for (int i = 0; i < slot.Count; i++)
        {
             if (NeedItem == slot[i].ItemInfo && NeedCount <= slot[i].Count)
                return i;
        }

        return -1;
    }
    
    // 빈 인벤을 찿아서 인자로 받아오는 아이템과 갯수를 넣어주는 함수
    public void FindEmptySlot(Item AddItem, int Count)
    {
        for (int i = 0; i < slot.Count; i++)
        {
            if (slot[i].ItemInfo == null)
            {
                slot[i].ItemInfo = AddItem;
                slot[i].Count = Count;
            }
        }
    }
}
