using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Need
{
    public Item NeedItem;
    public int NeedCount;
}

public class Conversation : MonoBehaviour
{
    [SerializeField] private List<Need> NeedItems = new List<Need>();
    private Button thisBtn;

    private void Awake()
    {
        thisBtn = this.GetComponent<Button>();
        thisBtn.onClick.AddListener(ClickConversation);
    }
    
    private void ClickConversation()
    {

    }
}
