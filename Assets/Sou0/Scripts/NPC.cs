using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using UnityEditor;

[System.Serializable]
public enum InteractionType
{
    NONE, SHOP, ITEM ,CONVERSATION, PLANT, STORAGESPACE
}

public interface Interaction_Info
{
    InteractionType Type { get; set; }
    bool enable { get; set; }

    void ActionKey();

}


public class NPC : MonoBehaviour, Interaction_Info
{
    [field: SerializeField] 
    public virtual InteractionType Type { get; set; }

    [field: SerializeField]
    public bool enable { get; set; }

    [SerializeField] private GameObject NearUi;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Interaction();
    }

    // ��ȣ�ۿ����� ������ �ൿ�� �����Լ�
    // ������ NPC�� ��ũ��Ʈ���� override�� ������ �Ͽ� ����
    public virtual void ActionKey() 
    {
    
    }

    // ��ȣ�ۿ� ����
    // ������ Ÿ�Կ� ���� ���������� �����ϴ� �κ��� �����Ű�� ������ �ൿ���� �Ѱ���
    // ���� �������� �ʴ� ����, ��ȭâ ���� �Ŀ� �ҿ���
    private void Interaction()
    {
        if (Input.GetKeyDown(KeyCode.F) && enable)
        {
#if UNITY_EDITOR
            Debug.Log("��ȣ�ۿ�");
            switch (Type)
            {
                case InteractionType.NONE:
                    Debug.LogError("Ÿ�Ծ���");
                    break;
                case InteractionType.SHOP:
                    Debug.Log("��������");
                    break;
                case InteractionType.ITEM:
                    Debug.Log("������ ȹ��");
                    break;
                case InteractionType.CONVERSATION:
                    Debug.Log("���۴����");
                    break;
                case InteractionType.PLANT:
                    Debug.Log("�Ĺ�����");
                    break;
                case InteractionType.STORAGESPACE:
                    Debug.Log("�������� ����");
                    break;
            }
#endif

            ActionKey();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enable = true;
            NearUi.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enable = false;
            NearUi?.SetActive(false);
        }
    }

}
