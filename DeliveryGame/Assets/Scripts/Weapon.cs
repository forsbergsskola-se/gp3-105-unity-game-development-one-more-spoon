using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Gun gun;
    public Bat bat;

    public Weapon(Gun gun, Bat bat)
    {
        this.gun = gun;
        this.bat = bat;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
