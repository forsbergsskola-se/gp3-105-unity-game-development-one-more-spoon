using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpeedDebuffZone : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
            other.gameObject.AddComponent<SpeedDebuff>();
            // other.gameObject add component of type speed buff
    }
}
