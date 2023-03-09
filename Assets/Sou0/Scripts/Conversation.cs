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
    SerializedProperty ConversationBtn;
    SerializedProperty AllRecipe;
    SerializedProperty SelectionItem;

    SerializedProperty FireCount;
    SerializedProperty RowType;

    SerializedProperty Temperture;

    private void OnEnable()
    {
        Type = serializedObject.FindProperty("Type");
        ConversationBtn = serializedObject.FindProperty("ConversationBtn");
        AllRecipe = serializedObject.FindProperty("AllRecipe");
        SelectionItem = serializedObject.FindProperty("SelectionItem");

        FireCount = serializedObject.FindProperty("FireCount");
        RowType = serializedObject.FindProperty("RowType");

        Temperture = serializedObject.FindProperty("Temperture");
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.PropertyField(Type);
        EditorGUILayout.PropertyField(ConversationBtn);
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
    [SerializeField] private Button ConversationBtn;
    [SerializeField] private List<Item> SelectionItem;
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
                                FindRecipeIngredientItem();
                                break;
                            case 2:
                                break;
                            case 3:
                                break;
                        }
                    }
                    break;
            }

        }
        
    }

    private bool FindRecipeIngredientItem()
    {
        for (int k = 0; k < 3; k++)
        {
            for (int i = 0; i < AllRecipe.Count; i++)
            {
                for (int j = 0; j < AllRecipe[i].IngredientItemInfo.Count; j++)
                {
                    if (AllRecipe[i].IngredientItemInfo[j] == SelectionItem[k])
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }
}
