using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private Image ItemImage;
    private Button thisBtn;
    private string Name;
    public int Count;
    public int MaxCount;
    public Item ItemInfo;

    private void Awake()
    {
        thisBtn = this.GetComponent<Button>();
        thisBtn.onClick.AddListener(ClickIcon);
    }

    private void FixedUpdate()
    {
        UIConstantChange();
    }

    private void ClickIcon()
    {
        Debug.Log(transform.localPosition);
    }

    // 인벤토리의 변화를 체크하여 변화시켜주는 함수
    // 스크립터블 오브젝트의 정보를 받아온다.
    private void UIConstantChange()
    {
        if (gameObject.activeSelf && ItemInfo != null)
        {
            //ItemImage.sprite = ItemInfo.ItemImage;
            MaxCount = ItemInfo.InvenMaxCount;
            Name = ItemInfo.ItemName;
        }
    }
}
