using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum InteractionType
{
    NONE, SHOP
}

public interface Interaction_Info
{
    InteractionType Type { get; set; }
    bool enable { get; set; }

    void ActionKey();

}

public class NPC : MonoBehaviour, Interaction_Info
{
    public InteractionType Type { get; set; }
    public bool enable { get; set; }

    public GameObject NearUi;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Debug.Log(enable);
        ActionKey();
    }

    public void ActionKey()
    {
        if (enable)
        {
            
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
