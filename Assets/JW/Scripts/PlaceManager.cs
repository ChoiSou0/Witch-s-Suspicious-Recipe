using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlaceManager : MonoBehaviour
{
    private Coroutine ObjectPlaceCoroutine;
    public GameObject Grid;

    void Start()
    {

    }

    void Update()
    {
        PlaceObjectTest();
    }

    private void PlaceObjectTest()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //ObjectPlaceCoroutine = StartCoroutine(PlaceObject());
        }
    }

    public void Temp()
    {
        ObjectPlaceCoroutine = StartCoroutine(PlaceObject(EventSystem.current.currentSelectedGameObject));
    }

    IEnumerator PlaceObject(GameObject Obj)
    {
        while (true)
        {
            //Debug.Log(Input.mousePosition);
            //Obj.transform.position = Input.mousePosition;
            Obj.transform.position = new Vector2((int)Input.mousePosition.x / 192 * 192 + 96, (int)Input.mousePosition.y / 108 * 108 + 54);
            Obj.GetComponent<Button>().enabled = false;
            Grid.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                Grid.SetActive(false);
                Obj.GetComponent<Button>().enabled = true;
                StopCoroutine(ObjectPlaceCoroutine);
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
