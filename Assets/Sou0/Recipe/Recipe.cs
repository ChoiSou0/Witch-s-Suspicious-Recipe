using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
[CustomEditor(typeof(Recipe))]
public class RecipeEditor : Editor
{
    SerializedProperty IngredientItemInfo;
    SerializedProperty NeedIngredientItemCount;
    SerializedProperty CombinationItemInfo;
    SerializedProperty AddCombinationItemCount;

    SerializedProperty FireCount;
    SerializedProperty RowingType;

    SerializedProperty Temperature;

    SerializedProperty table;

    private void OnEnable()
    {
        IngredientItemInfo = serializedObject.FindProperty("IngredientItemInfo");
        NeedIngredientItemCount = serializedObject.FindProperty("NeedIngredientItemCount");
        CombinationItemInfo = serializedObject.FindProperty("CombinationItemInfo");
        AddCombinationItemCount = serializedObject.FindProperty("AddCombinationItemCount");

        FireCount = serializedObject.FindProperty("FireCount");
        RowingType = serializedObject.FindProperty("RowingType");

        Temperature = serializedObject.FindProperty("Temperature");

        table = serializedObject.FindProperty("table");
    }
    public override void OnInspectorGUI()
    {
        EditorGUILayout.PropertyField(IngredientItemInfo);
        EditorGUILayout.PropertyField(NeedIngredientItemCount);
        EditorGUILayout.PropertyField(CombinationItemInfo);
        EditorGUILayout.PropertyField(AddCombinationItemCount);

        EditorGUILayout.PropertyField(table);

        switch (table.enumValueFlag)
        {
            case (int)CombinationTable.OVEN:
                EditorGUILayout.Space(20);
                EditorGUILayout.PropertyField(Temperature);
                break;

            case (int)CombinationTable.KETTLE:
                EditorGUILayout.Space(20);
                EditorGUILayout.PropertyField(FireCount);
                EditorGUILayout.PropertyField(RowingType);
                break;
        }

        serializedObject.ApplyModifiedProperties();
    }
}
#endif

public enum CombinationTable
{
    OVEN, KETTLE
}

public enum RowingType
{
    TURNLEFT, TURNRIGHT, ZIGZAG, NO
}

[CreateAssetMenu(fileName = "RecipeInfo", menuName = "Scriptavle Object Asset/RecipeInfo")]
public class Recipe : ScriptableObject
{
    public CombinationTable table;
    public List<Item> IngredientItemInfo;
    public List<int> NeedIngredientItemCount;

    public Item CombinationItemInfo;
    public int AddCombinationItemCount;

    public int Temperature;

    public int FireCount;
    public RowingType RowingType;

}
