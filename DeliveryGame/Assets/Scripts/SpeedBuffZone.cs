using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpeedBuffZone : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
            other.gameObject.AddComponent<SpeedBuff>();
            // other.gameObject add component of type speed buff
    }
}
