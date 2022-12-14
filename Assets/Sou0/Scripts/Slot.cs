using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    private Button thisBtn;
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
        
    }

    private void ClickIcon()
    {
        Debug.Log(transform.localPosition);
    }
}
