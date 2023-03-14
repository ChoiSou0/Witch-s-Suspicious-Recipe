using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlaceManager : MonoBehaviour
{
    private Coroutine ObjectPlaceCoroutine;
    public GameObject Grid;
    public GameObject DecoInventory;

    public int CrashCount;

    void Start()
    {

    }

    void Update()
    {

    }

    public void SelectThisObj()
    {
        if (CrashCount == 0)
        {
            ObjectPlaceCoroutine = StartCoroutine(PlaceObject(EventSystem.current.currentSelectedGameObject));
        }
    }

    public void ClickInInventory()
    {
        ObjectPlaceCoroutine = StartCoroutine(PlaceObject(Instantiate(EventSystem.current.currentSelectedGameObject.GetComponent<PlaceObj>().CopyObj, transform.position, Quaternion.identity, GameObject.Find("Canvas").transform)));
        DecoInventory.SetActive(false);
    }

    IEnumerator PlaceObject(GameObject Obj)
    {
        while (true)
        {
            //Debug.Log(Input.mousePosition);
            //Obj.transform.position = Input.mousePosition;
            Obj.transform.position = new Vector2((int)Input.mousePosition.x / 192 * 192 + 96, (int)Input.mousePosition.y / 108 * 108 + 54);
            Debug.Log(Obj.transform.position.y);
            if (Obj.transform.position.x < 96)
            {
                Obj.transform.position = new Vector2(96, Obj.transform.position.y);
            }
            else if (Obj.transform.position.x > 1824)
            {
                Obj.transform.position = new Vector2(1824, Obj.transform.position.y);
            }
            if (Obj.transform.position.y < 54)
            {
                Obj.transform.position = new Vector2(Obj.transform.position.x, 54);
            }
            if (Obj.transform.position.y > 1026)
            {
                Obj.transform.position = new Vector2(Obj.transform.position.x, 1026);
            }
            Obj.GetComponent<Button>().enabled = false;
            Grid.SetActive(true);
            if (Input.GetMouseButtonDown(0) && CrashCount == 0)
            {
                Grid.SetActive(false);
                Obj.GetComponent<Button>().enabled = true;
                StopCoroutine(ObjectPlaceCoroutine);
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
