using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    public Vector3 cameraOffset;
    public Vector3 cameraRotationOffset;
    public float cameraDelay = 3.96f;
    

    private void LateUpdate()
    {
        Vector3 targetPosition = player.transform.position + player.transform.TransformDirection(this.cameraOffset);
        this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, Time.deltaTime * cameraDelay);
        
        this.transform.rotation = player.transform.rotation * Quaternion.Euler(this.cameraRotationOffset);
        

    }
}