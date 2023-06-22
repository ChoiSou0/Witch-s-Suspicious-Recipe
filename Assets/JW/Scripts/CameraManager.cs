using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class CameraManager : MonoBehaviour
{
	private Transform parentTransform;
	private Transform cameraTransform;

	[SerializeField] private float rangeX;
	[SerializeField] private float rangeY;

	private Vector3 targetPosition;

	void Awake()
	{
		parentTransform = transform.parent;
		cameraTransform = transform;
	}

	void Start()
	{
		targetPosition = new Vector3(0, 0, -10);
		parentTransform = GameObject.Find("Player").transform;
		cameraTransform = parentTransform.GetChild(1).transform;
	}

	void Update()
	{
		float parentX = parentTransform.position.x;
		float parentY = parentTransform.position.y;

		targetPosition.x = Mathf.Clamp(parentX, -rangeX + transform.position.x, rangeX + transform.position.x);
		targetPosition.y = Mathf.Clamp(parentY, -rangeY + transform.position.y, rangeY + transform.position.y);

		cameraTransform.position = targetPosition;
	}

#if UNITY_EDITOR
	private void OnDrawGizmos()
	{
		GameObject targetobj = GameObject.Find("CameraRange");
		UnityEditor.Handles.color = Color.green;
		UnityEditor.Handles.DrawWireCube(transform.position, new Vector3(rangeX * 2, rangeY * 2, 0));
	}
#endif
}