using UnityEngine;

[System.Serializable]
public enum ItemType
{
    NONE, Ingredient, Food, Potion
}

[CreateAssetMenu(fileName = "ItemInfo" ,menuName = "Scriptavle Object Asset/ItemInfo")]
public class Item : ScriptableObject
{
    public ItemType itemtype;
    public string ItemName;
    public int InvenMaxCount;
    public Sprite ItemImage;
}
