using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeManager : MonoBehaviour
{
	public GameObject volume;

	bool state = true;

	void Start()
	{
		if (PlayerPrefs.GetInt("sound_on") == 1)
		{
			state = true;
			volume.SetActive(true);
		}
		else
		{
			state = false;
			volume.SetActive(false);
		}
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.tag == "volume")
				{
					Debug.Log("Here");
					if (state == true)
					{
						PlayerPrefs.SetInt("sound_on", 0);
						state = false;
						volume.SetActive(false);
					}
					else
					{
						PlayerPrefs.SetInt("sound_on", 1);
						state = true;
						volume.SetActive(true);
					}
				}
			}
		}
	}
}
