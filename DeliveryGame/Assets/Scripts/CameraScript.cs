using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Vector2 rotate;
    public float mouseSensitivity = 0.5f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotate.y += Input.GetAxis("Mouse Y") * mouseSensitivity;
        rotate.x += Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.localRotation = Quaternion.Euler(-rotate.y, rotate.x, 0);
    }
}
