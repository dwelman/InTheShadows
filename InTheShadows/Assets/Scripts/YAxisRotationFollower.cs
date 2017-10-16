using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YAxisRotationFollower : MonoBehaviour
{
    public GameObject followObject;

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(followObject.transform.right);
    }
}
