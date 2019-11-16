using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFacing: MonoBehaviour
{
    public GameObject mainCamera;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward,
            mainCamera.transform.rotation * Vector3.up);
    }
}
