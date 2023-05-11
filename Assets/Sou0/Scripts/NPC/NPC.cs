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

    // 상호작용으로 나오는 행동의 가상함수
    // 각각의 NPC에 스크립트에서 override로 재정의 하여 만듬
    public virtual void ActionKey() 
    {
    
    }

    // 상호작용 시작
    // 각각의 타입에 따라서 공통적으로 실행하는 부분을 실행시키고 각자의 행동으로 넘겨줌
    // 현재 구현하지 않는 이유, 대화창 구현 후에 할예정
    private void Interaction()
    {
        if (Input.GetKeyDown(KeyCode.F) && enable)
        {
#if UNITY_EDITOR
            Debug.Log("상호작용");
            switch (Type)
            {
                case InteractionType.NONE:
                    Debug.LogError("타입없음");
                    break;
                case InteractionType.SHOP:
                    Debug.Log("상점오픈");
                    break;
                case InteractionType.ITEM:
                    Debug.Log("아이템 획득");
                    break;
                case InteractionType.CONVERSATION:
                    Debug.Log("제작대오픈");
                    break;
                case InteractionType.PLANT:
                    Debug.Log("식물수집");
                    break;
                case InteractionType.STORAGESPACE:
                    Debug.Log("수납공간 오픈");
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
