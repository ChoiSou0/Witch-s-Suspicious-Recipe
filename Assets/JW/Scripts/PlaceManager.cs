using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlaceManager : MonoBehaviour
{
	private Coroutine objectPlaceCoroutine;
	public GameObject grid;
	public GameObject decoInventory;

	public GameObject originalItem;
	public GameObject inventoryList;

	public int crashCount;

	void Start()
	{

	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			CreateNewItem("Obj1", "character_Mode@4x");
		}
		if (Input.GetKeyDown(KeyCode.W))
		{
			CreateNewItem("Obj2", "Create_Vertex@4x");
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			CreateNewItem("Obj3", "Create Bones@4x");
		}
		if (Input.GetKeyDown(KeyCode.R))
		{
			CreateNewItem("Obj4", "Copy@4x");
		}
	}

	private void CreateNewItem(string ObjectName, string ImageName)
	{
		GameObject Temp = Instantiate(originalItem, transform.position, Quaternion.identity, inventoryList.transform);
		Temp.GetComponent<PlaceObj>().copyObj = GameObject.Find(ObjectName);
		Temp.GetComponent<Image>().sprite = Resources.Load<Sprite>(ImageName);
	}

	public void SelectThisObj()
	{
		if (crashCount == 0)
		{
			objectPlaceCoroutine = StartCoroutine(PlaceObject(EventSystem.current.currentSelectedGameObject));
		}
	}

	public void ClickInInventory()
	{
		objectPlaceCoroutine = StartCoroutine(PlaceObject(Instantiate(EventSystem.current.currentSelectedGameObject.GetComponent<PlaceObj>().copyObj, transform.position, Quaternion.identity, GameObject.Find("DecorateCanvas").transform)));
		decoInventory.SetActive(false);
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
			grid.SetActive(true);
			if (Input.GetMouseButtonDown(0) && crashCount == 0)
			{
				grid.SetActive(false);
				Obj.GetComponent<Button>().enabled = true;
				StopCoroutine(objectPlaceCoroutine);
			}
			yield return new WaitForSeconds(Time.deltaTime);
		}
	}
}
