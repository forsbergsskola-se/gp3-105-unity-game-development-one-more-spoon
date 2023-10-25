using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffectTimeout : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public IEnumerator FireTimeOut()
    {
        yield return new WaitForSeconds(5);
        ParticleSystem fireParticleSystem = this.GetComponent<ParticleSystem>();
        fireParticleSystem.Stop();
    }
    
}
