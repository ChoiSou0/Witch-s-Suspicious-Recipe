using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	}

	void Update()
	{
		float parentX = parentTransform.position.x;
		float parentY = parentTransform.position.y;

		targetPosition.x = Mathf.Clamp(parentX, -rangeX, rangeX);
		targetPosition.y = Mathf.Clamp(parentY, -rangeY, rangeY);

		cameraTransform.position = targetPosition;
	}
}