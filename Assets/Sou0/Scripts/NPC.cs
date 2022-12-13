using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using UnityEditor;

[System.Serializable]
public enum InteractionType
{
    NONE, SHOP, CONVERSATION
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
        
    }

    public virtual void ActionKey() { }
    
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
