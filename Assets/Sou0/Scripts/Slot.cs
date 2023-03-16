using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private Image ItemImage;
    private Image Conversation_Pnl;
    private Conversation conversation;
    private Button thisBtn;
    private string Name;
    public int Count;
    public int MaxCount;
    public Item ItemInfo;

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
        if (Conversation_Pnl.gameObject.activeSelf)
        {
            switch (conversation.SelectionItem.Count)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }
    }

    // �κ��丮�� ��ȭ�� üũ�Ͽ� ��ȭ�����ִ� �Լ�    
    // ��ũ���ͺ� ������Ʈ�� ������ �޾ƿ´�.
    private void UIConstantChange()
    {
        if (gameObject.activeSelf && ItemInfo != null)
        {
            //ItemImage.sprite = ItemInfo.ItemImage;
            MaxCount = ItemInfo.InvenMaxCount;
            Name = ItemInfo.ItemName;
        }
        
        if (Count <= 0)
        {
            //ItemImage.sprite = null;
            MaxCount = 0;
            ItemInfo = null;
        }
    }
}
