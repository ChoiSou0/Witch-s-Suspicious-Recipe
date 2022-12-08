using UnityEngine;

[System.Serializable]
public enum ItemType
{
    NONE, Ingredient, FOOD
}

[CreateAssetMenu(fileName = "ItemInfo" ,menuName = "Scriptavle Object Asset/ItemInfo")]
public class Item : ScriptableObject
{
    public ItemType itemtype;
    public string ItemName;
    [SerializeField] private Sprite ItemImage;
}
