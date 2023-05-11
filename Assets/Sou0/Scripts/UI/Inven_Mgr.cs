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

    // �κ��丮�� ���� �ְ� ���� ������ ���� �ٸ� �Լ�
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

    // �ش� �������� ã�Ƽ� ��Ʈ������ ��ȯ���ִ� �Լ�
    // �ϴ��� �����ڵ忡 ������ +1�� 1�� �������� ������ ����̶�
    // ���Ŀ� �����ؾ� �� ���� ����
    public int FindSlot(Item NeedItem, int NeedCount)
    {
        for (int i = 0; i < slot.Count; i++)
        {
             if (NeedItem == slot[i].ItemInfo && NeedCount <= slot[i].Count)
                return i;
        }

        return -1;
    }
    
    // �� �κ��� �O�Ƽ� ���ڷ� �޾ƿ��� �����۰� ������ �־��ִ� �Լ�
    public void FindEmptySlot(Item AddItem, int Count)
    {
        for (int i = 0; i < slot.Count; i++)
        {
            if (slot[i].ItemInfo == null)
            {
                slot[i].ItemInfo = AddItem;
                slot[i].Name = AddItem.ItemName;
                slot[i].Count = Count;
                slot[i].MaxCount = AddItem.InvenMaxCount;
                slot[i].ItemImage.sprite = AddItem.ItemImage;
                break;
            }
        }
    }

    public void InvenClean()
    {
        for (int i = 0; i < slot.Count; i++)
        {
            if (slot[i].Count == 0)
            {
                if (slot[i].ItemInfo == null)
                    break;

                slot[i].ItemInfo = slot[i + 1].ItemInfo;
                slot[i].MaxCount = slot[i + 1].MaxCount;
                slot[i].Count = slot[i + 1].Count;
                slot[i].Name = slot[i + 1].Name;
                slot[i].ItemImage = slot[i + 1].ItemImage;
                
                slot[i + 1].MaxCount = 0;
                slot[i + 1].Count = 0;
                slot[i + 1].Name = null;
                slot[i + 1].ItemImage = null;

            }
        }
    }
}
