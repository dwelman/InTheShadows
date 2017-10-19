using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public enum LevelControlTypes { Horizontal = 0, HorizontalAndVertical = 1, MultipleObjects = 2};

	public LevelControlTypes levelControlType;
	public List<RotationObject> rotationObjects;
	public float rotationSpeed = 30f;
	public RotationObject objectOriginPoint;
	public int level;
    public GameObject confetti;
    public AudioClip party;

	Vector3 lastMousePos;
	RotationObject currentRotationObject;
	int currentObjectIndex = 0;
    bool levelComplete = false;

	void Awake()
	{
		currentRotationObject = rotationObjects[0];
        currentRotationObject.axes.SetActive(true);
    }

	void Update()
	{
		Vector3 mousePos = Input.mousePosition;
		Vector3 mouseDir = mousePos - lastMousePos;

        if (!levelComplete)
        {
            currentRotationObject.axes.SetActive(true);
            if (objectOriginPoint)
            {
                objectOriginPoint.axes.SetActive(false);
            }
            if (levelControlType >= LevelControlTypes.MultipleObjects && Input.GetKey(KeyCode.LeftShift))
            {
                currentRotationObject.axes.SetActive(false);
                objectOriginPoint.axes.SetActive(true);
                if (Input.GetMouseButton(0))
                {
                    objectOriginPoint.transform.RotateAround(objectOriginPoint.transform.position, new Vector3(0, 1, 0), rotationSpeed * mouseDir.x * Time.deltaTime * -1);
                }
            }
            else if (levelControlType >= LevelControlTypes.HorizontalAndVertical && Input.GetKey(KeyCode.LeftControl))
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
                for (int i = 0; i < rotationObjects.Count; i++)
                {
                    rotationObjects[i].ResetRotation();
                }
                if (objectOriginPoint)
                {
                    objectOriginPoint.ResetRotation();
                }
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                SwitchCurrentRotationObject();
            }
        }
        bool levelVictory = true;
        if (objectOriginPoint)
        {
            levelVictory = objectOriginPoint.CheckVictoryCondition();
        }
        for (int i = 0; i < rotationObjects.Count; i++)
        {
            if (!rotationObjects[i].CheckVictoryCondition())
            {
                levelVictory = false;
                break;
            }
        }
        if (levelVictory && !levelComplete)
        {
            levelComplete = true;
            Vector3 pos;
            if (objectOriginPoint)
            {
                pos = objectOriginPoint.transform.position;
            }
            else
            {
                pos = currentRotationObject.transform.position;
            }
            if (PlayerPrefs.GetInt("sound_on") == 1)
            {
                GetComponent<AudioSource>().PlayOneShot(party);
            }
            GameObject.Instantiate(confetti, pos, confetti.transform.rotation);
            confetti.transform.position = pos;
			StartCoroutine("ReturnToLevelSelect");
			PlayerPrefs.SetInt("level", level);
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
        currentRotationObject.axes.SetActive(false);
        currentRotationObject = rotationObjects[currentObjectIndex];
        currentRotationObject.axes.SetActive(true);
    }

	IEnumerator ReturnToLevelSelect()
	{
		yield return new WaitForSeconds(2.5f);
		SceneManager.LoadScene("mainMenu");
	}
}
