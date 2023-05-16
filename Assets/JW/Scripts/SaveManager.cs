using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
	static GameObject container;

	static SaveManager instance;
	public static SaveManager Instance
	{
		get
		{
			if (!instance)
			{
				container = new GameObject();
				container.name = "SaveManager";
				instance = container.AddComponent(typeof(SaveManager)) as SaveManager;
				DontDestroyOnLoad(container);
			}
			return instance;
		}
	}

	string GameDataFileName = "GameData.json";

	public Data data = new Data();

	public void LoadGameData()
	{
		string filePath = Application.dataPath + "/" + GameDataFileName;

		if (File.Exists(filePath))
		{
			string FromJsonData = File.ReadAllText(filePath);
			data = JsonUtility.FromJson<Data>(FromJsonData);
			Debug.Log("불러오기 완료");
		}
	}

	public void SaveGameData()
	{
		string ToJsonData = JsonUtility.ToJson(data, true);
		string filePath = Application.dataPath + "/" + GameDataFileName;

		File.WriteAllText(filePath, ToJsonData);

		Debug.Log("저장하기 완료");
	}
}