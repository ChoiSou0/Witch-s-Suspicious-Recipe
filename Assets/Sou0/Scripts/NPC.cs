using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum NPCType
{
    None, Shop, CombinationTable
}

public class NPC : MonoBehaviour
{
    [SerializeField] private NPCType type;
    [SerializeField] private GameObject NearUi;
    [SerializeField] private bool isNearby;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InteractionNPC()
    {
                                                                                                                              
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("UI ON");
            isNearby = true;
            NearUi.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("UI OFF");
            isNearby = false;
            NearUi.SetActive(false);
        }
    }
}
