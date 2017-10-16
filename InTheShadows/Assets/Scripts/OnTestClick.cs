using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTestClick : MonoBehaviour
{
    public Camera camera;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.gameObject.name.ToString());
            }
        }
    }
}
