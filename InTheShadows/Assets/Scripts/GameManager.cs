using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public enum LevelControlTypes { Horizontal = 0, HorizontalAndVertical = 1, MultipleObjects = 2};

	public LevelControlTypes levelControlType;
	public List<RotationObject> rotationObjects;
	public float rotationSpeed = 30f;

	Vector3 lastMousePos;
	RotationObject currentRotationObject;
	int currentObjectIndex = 0;

	void Awake()
	{
		currentRotationObject = rotationObjects[0];
	}

	void Update()
	{
		Vector3 mousePos = Input.mousePosition;
		Vector3 mouseDir = mousePos - lastMousePos;
		if (levelControlType >= LevelControlTypes.HorizontalAndVertical && Input.GetKey(KeyCode.LeftControl))
		{
			if (Input.GetMouseButton(0))
			{

                currentRotationObject.transform.Rotate(rotationSpeed * mouseDir.y * Time.deltaTime, 0, 0, Space.Self);
			}
		}
		else if (levelControlType >= LevelControlTypes.Horizontal)
		{
			if (Input.GetMouseButton(0))
			{
				currentRotationObject.transform.RotateAround(currentRotationObject.transform.position, new Vector3(0, 1, 0), rotationSpeed * mouseDir.x * Time.deltaTime * -1);
			}
		}

		if (Input.GetKeyUp(KeyCode.R))
		{
			currentRotationObject.ResetRotation();
		}
		if (Input.GetKeyUp(KeyCode.Space))
		{
			SwitchCurrentRotationObject();
		}

		bool levelVictory = true;
		for (int i = 0; i < rotationObjects.Count; i++)
		{
			if (!rotationObjects[i].CheckVictoryCondition())
			{
				levelVictory = false;
				break;
			}
		}
		if (levelVictory)
		{
			Debug.Log("Level complete");
		}
		lastMousePos = mousePos;
	}

	void SwitchCurrentRotationObject()
	{
		currentObjectIndex++;
		if (currentObjectIndex == rotationObjects.Count)
		{
			currentObjectIndex = 0;
		}
		currentRotationObject = rotationObjects[currentObjectIndex];
	}
}
