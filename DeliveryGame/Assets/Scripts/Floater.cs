using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
// This script makes the object move up and down.

public class Floater : MonoBehaviour
{

public float amplitude = 0.5f;
public float frequency = 1f;

// Position Storage Variables
Vector3 posOffset;
Vector3 tempPos;

void Start () {
// Store the starting position 
    posOffset = transform.position;
}

void Update () {

// Float up/down with a Sin()
    tempPos = posOffset;
    tempPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;

    transform.position = tempPos;
}
}
   
