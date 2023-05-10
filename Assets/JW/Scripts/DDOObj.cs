using UnityEngine;

public class DDOObj : MonoBehaviour
{
	public static DDOObj Instance;

	private void Awake()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
			return;
		}

		Instance = this;
		DontDestroyOnLoad(gameObject);
	}
}
