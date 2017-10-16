using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayClick : MonoBehaviour {

	public Camera camera;

	void Update ()
	{
		if (Input.GetMouseButtonDown(0))
		{ // if left button pressed...
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				Debug.Log ("hi");
			}
		}
	}
}
