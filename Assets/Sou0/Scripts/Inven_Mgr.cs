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

    public int FindSlot(Item NeedItem, int NeedCount)
    {
        int Finded;

        for (int i = 0; i < slot.Count; i++)
        {
            if (NeedItem == slot[i].ItemInfo && NeedCount < slot[i].Count)
            {
                Finded = i;

                return i;
            }
        }

        return 0;
    }
    
}
