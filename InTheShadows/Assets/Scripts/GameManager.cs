using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public enum LevelControlTypes { Horizontal = 0, HorizontalAndVertical = 1, MultipleObjects = 2};

	public LevelControlTypes levelControlType;
	public GameObject rotationObject;
	public float rotationSpeed = 30f;

	private Vector3 lastMousePos;

	void Update()
	{
		Vector3 mousePos = Input.mousePosition;
		Vector3 mouseDir = mousePos - lastMousePos;
		if (levelControlType >= LevelControlTypes.HorizontalAndVertical && Input.GetKey(KeyCode.LeftControl))
		{
			if (Input.GetMouseButton(0))
			{
				rotationObject.transform.RotateAround(rotationObject.transform.position, new Vector3(1, 0, 0), rotationSpeed * mouseDir.y * Time.deltaTime);
			}
		}
		else if (levelControlType >= LevelControlTypes.Horizontal)
		{
			if (Input.GetMouseButton(0))
			{
				rotationObject.transform.RotateAround(rotationObject.transform.position, new Vector3(0, 1, 0), rotationSpeed * mouseDir.x * Time.deltaTime * -1);
			}
		}
		lastMousePos = mousePos;
	}
}
