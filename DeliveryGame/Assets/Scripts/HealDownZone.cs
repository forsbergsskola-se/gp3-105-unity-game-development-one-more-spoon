using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealDownZone : MonoBehaviour
{
    private PlayerController playerController;

    private void OnTriggerStay(Collider other)
    {
        other.gameObject.AddComponent<HealDown>();
        // other.gameObject add component of type speed buff
    }
}

