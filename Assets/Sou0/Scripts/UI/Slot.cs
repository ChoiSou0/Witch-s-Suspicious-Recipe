using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Image ItemImage;
    private Image Conversation_Pnl;
    private Conversation conversation;
    private Button thisBtn;
    public string Name;
    public int Count;
    public int MaxCount;
    public Item ItemInfo;
    public bool SlotAwake = false;
    [SerializeField] private Sprite DontAwakeImage;

    private void Awake()
    {
        thisBtn = this.GetComponent<Button>();
        Conversation_Pnl = GameObject.FindObjectOfType<Image>();
        conversation = GameObject.FindObjectOfType<Conversation>();
        thisBtn.onClick.AddListener(ClickIcon);
    }

    private void Update()
    {
        UIConstantChange();
    }

    // �������� Ŭ������ ��, �������� ����â�� ������ �ϴ°�
    // �� �ϴ� ����, ���� ���� ����� �������� ����
    private void ClickIcon()
    {
        Debug.Log(transform.localPosition);
        if (Conversation_Pnl.gameObject.activeSelf && ItemInfo != null)
        {
            switch (conversation.SelectionItem.Count)
            {
                case 0:
                    conversation.SelectionItem.Add(ItemInfo);
                    conversation.SelectionTxt[0].text = Count.ToString();
                    break;
                case 1:
                    if (conversation.SelectionItem[0] != ItemInfo)
                    {
                        conversation.SelectionItem.Add(ItemInfo);
                        conversation.SelectionTxt[1].text = Count.ToString();
                    }
                    break;
                case 2:
                    if (conversation.SelectionItem[0] != ItemInfo &&
                        conversation.SelectionItem[1] != ItemInfo)
                    {
                        conversation.SelectionItem.Add(ItemInfo);
                        conversation.SelectionTxt[2].text = Count.ToString();
                    }
                    break;
                case 3:
                    Debug.Log("���ò���");
                    break;
            }
        }
    }

    // �κ��丮�� ��ȭ�� üũ�Ͽ� ��ȭ�����ִ� �Լ�    
    // ��ũ���ͺ� ������Ʈ�� ������ �޾ƿ´�.
    private void UIConstantChange()
    {
        if (SlotAwake)
        {
            if (gameObject.activeSelf && ItemInfo != null)
            {
                ItemImage.sprite = ItemInfo.ItemImage;
                MaxCount = ItemInfo.InvenMaxCount;
                Name = ItemInfo.ItemName;
            }

            if (Count <= 0)
            {
                ItemImage.sprite = null;
                MaxCount = 0;
                ItemInfo = null;
            }
        }
        else
        {
            ItemImage.sprite = DontAwakeImage;
            Debug.Log("����");
            
        }
    }
}
