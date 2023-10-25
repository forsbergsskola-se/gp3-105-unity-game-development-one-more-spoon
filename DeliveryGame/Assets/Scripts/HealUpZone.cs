using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealUpZone : MonoBehaviour
{
    private PlayerController playerController;

    private void OnTriggerStay(Collider other)
    {
        other.gameObject.AddComponent<HealUp>();
        // other.gameObject add component of type speed buff
    }
}

