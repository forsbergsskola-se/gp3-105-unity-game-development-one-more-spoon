using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using TMPro;
public class Gun : MonoBehaviour
{
    public int ammoLeft = 12;
    public int clipSize = 12;
    public int ammoStored = 100;
    public bool isEquipped = false;
    public TMP_Text ammoText;
    public TMP_Text ammoStoredText;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.SetText(ammoLeft.ToString());
        ammoStoredText.SetText(ammoStored.ToString());
    }

    public void RemoveAmmo()
    {
        ammoLeft -= 1;
    }
    public void ReloadGun()
    {
        if (ammoStored > 0 && ammoLeft < clipSize)
        {
            if (ammoStored < 12)
            {
                ammoLeft = ammoStored;
                ammoStored = 0;
            }
            else
            {
                ammoStored -= clipSize;
                ammoLeft = clipSize;
            }

            if (ammoStored < 0)
            {
                ammoStored = 0;
            }
        }
    }
}
