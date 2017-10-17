using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousRotation : MonoBehaviour
{
	public Vector3 axis;
    public float rotationSpeed = 180;

    private void Update()
    {
        transform.Rotate(axis * rotationSpeed * Time.deltaTime, Space.Self);
    }
}
