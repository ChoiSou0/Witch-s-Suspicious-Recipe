using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceObj : MonoBehaviour
{
    public GameObject CopyObj;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Find("PlaceManager").GetComponent<PlaceManager>().CrashCount++;
        this.GetComponent<Image>().color = new Color(1, 0, 0, 100f / 255);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject.Find("PlaceManager").GetComponent<PlaceManager>().CrashCount--;
        this.GetComponent<Image>().color = new Color(0, 0, 0);
    }
}
