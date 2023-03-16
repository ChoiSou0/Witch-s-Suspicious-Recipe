using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
[CustomEditor(typeof(Conversation))]
public class ConversationEditor : Editor
{
    SerializedProperty Type;
    SerializedProperty Conversation_Pnl;
    SerializedProperty Inven_Pnl;
    SerializedProperty AllRecipe;
    SerializedProperty SelectionItem;

    SerializedProperty FireCount;
    SerializedProperty RowType;

    SerializedProperty Temperture;

    private void OnEnable()
    {
        Type = serializedObject.FindProperty("Type");
        Conversation_Pnl = serializedObject.FindProperty("Conversation_Pnl");
        Inven_Pnl = serializedObject.FindProperty("Inven_Pnl");
        AllRecipe = serializedObject.FindProperty("AllRecipe");
        SelectionItem = serializedObject.FindProperty("SelectionItem");

        FireCount = serializedObject.FindProperty("FireCount");
        RowType = serializedObject.FindProperty("RowType");

        Temperture = serializedObject.FindProperty("Temperture");
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.PropertyField(Type);
        EditorGUILayout.PropertyField(Conversation_Pnl);
        EditorGUILayout.PropertyField(Inven_Pnl);
        EditorGUILayout.PropertyField(AllRecipe);
        EditorGUILayout.PropertyField(SelectionItem);

        switch (Type.enumValueFlag)
        {
            case (int)ConversationType.OVEN:
                EditorGUILayout.PropertyField(Temperture);
                break;
            case (int)ConversationType.KETTLE:
                EditorGUILayout.PropertyField(FireCount);
                EditorGUILayout.PropertyField(RowType);
                break;
        }

        serializedObject.ApplyModifiedProperties();
    }
}
#endif

public enum ConversationType
{
    OVEN, KETTLE
}

public class Conversation : MonoBehaviour
{
    [SerializeField] private ConversationType Type;
    private Inven_Mgr inven_Mgr;
    [SerializeField] private Image Conversation_Pnl;
    [SerializeField] private Image Inven_Pnl;
    public List<Item> SelectionItem;
    [SerializeField] private List<Recipe> AllRecipe;

    [SerializeField, Range(1, 5)] private int FireCount = 1;
    [SerializeField] private RowingType RowType = RowingType.TURNLEFT;

    [SerializeField] private int Temperture;


    private void Awake()
    {
        inven_Mgr = GameObject.FindObjectOfType<Inven_Mgr>();


    }
    
    // 클릭할 시에 아이템 조합이 이루어 지는 함수
    public void ClickConversation()
    {
        int sel1, sel2, sel3;

        for (int i = 0; i < AllRecipe.Count; i++)
        {
            switch(Type)
            {
                case ConversationType.OVEN:
                    break;
                case ConversationType.KETTLE:
                    if (AllRecipe[i].FireCount == FireCount)
                    {
                        switch (SelectionItem.Count)
                        {
                            case 1:
                                if (SelectionItem[0] == AllRecipe[i].IngredientItemInfo[0])
                                {
                                    sel1 = inven_Mgr.FindSlot(SelectionItem[0], AllRecipe[i].NeedIngredientItemCount[0]);

                                    if (sel1 != -1)
                                    {
                                        inven_Mgr.slot[sel1].Count -= AllRecipe[i].NeedIngredientItemCount[0];

                                        inven_Mgr.FindEmptySlot(AllRecipe[i].CombinationItemInfo, AllRecipe[i].AddCombinationItemCount);
                                    }
                                }
                                break;
                            case 2:
                                if (SelectionItem[0] == AllRecipe[i].IngredientItemInfo[0] &&
                                    SelectionItem[1] == AllRecipe[i].IngredientItemInfo[1])
                                {
                                    sel1 = inven_Mgr.FindSlot(SelectionItem[0], AllRecipe[i].NeedIngredientItemCount[0]);
                                    sel2 = inven_Mgr.FindSlot(SelectionItem[1], AllRecipe[i].NeedIngredientItemCount[1]);
                                    
                                    if (sel1 != -1 && sel2 != -1)
                                    {
                                        inven_Mgr.slot[sel1].Count -= AllRecipe[i].NeedIngredientItemCount[0];
                                        inven_Mgr.slot[sel2].Count -= AllRecipe[i].NeedIngredientItemCount[1];

                                        inven_Mgr.FindEmptySlot(AllRecipe[i].CombinationItemInfo, AllRecipe[i].AddCombinationItemCount);
                                    }
                                }
                                break;
                            case 3:
                                if (SelectionItem[0] == AllRecipe[i].IngredientItemInfo[0] &&
                                    SelectionItem[1] == AllRecipe[i].IngredientItemInfo[1] &&
                                    SelectionItem[2] == AllRecipe[i].IngredientItemInfo[2])
                                {
                                    sel1 = inven_Mgr.FindSlot(SelectionItem[0], AllRecipe[i].NeedIngredientItemCount[0]);
                                    sel2 = inven_Mgr.FindSlot(SelectionItem[1], AllRecipe[i].NeedIngredientItemCount[1]);
                                    sel3 = inven_Mgr.FindSlot(SelectionItem[2], AllRecipe[i].NeedIngredientItemCount[2]);

                                    if (sel1 != -1 && sel2 != -1 && sel3 != -1)
                                    {
                                        inven_Mgr.slot[sel1].Count -= AllRecipe[i].NeedIngredientItemCount[0];
                                        inven_Mgr.slot[sel2].Count -= AllRecipe[i].NeedIngredientItemCount[1];
                                        inven_Mgr.slot[sel3].Count -= AllRecipe[i].NeedIngredientItemCount[2];

                                        inven_Mgr.FindEmptySlot(AllRecipe[i].CombinationItemInfo, AllRecipe[i].AddCombinationItemCount);
                                    }
                                }
                                break;
                        }
                    }
                    break;
            }

        }
        
    }

    public void Fire1BtnClick()
    {
        FireCount = 1;
    }

    public void Fire2BtnClick()
    {
        FireCount = 2;
    }

    public void Fire3BtnClick()
    {
        FireCount = 3;
    }

    public void Fire4BtnClick()
    {
        FireCount = 4;
    }

    public void Fire5BtnClick()
    {
        FireCount = 5;
    }

    public void TurnLeftBtnClick()
    {
        RowType = RowingType.TURNLEFT;
    }

    public void TurnRightBtnClick()
    {
        RowType = RowingType.TURNRIGHT;
    }

    public void TurnZigzagBtnClick()
    {
        RowType = RowingType.ZIGZAG;
    }

    public void TurnNoBtnClick()
    {
        RowType = RowingType.NO;
    }

    public void ConversationCancelBtnClick()
    {
        Conversation_Pnl.gameObject.SetActive(false);
        Inven_Pnl.gameObject.SetActive(true);
    }
}
