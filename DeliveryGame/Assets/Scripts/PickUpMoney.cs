using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// I just copied this from Imposible Game 3D. I need to change ome stuff.

public class StartGameButton : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.Rotate(2, 2, 2);
    }

    public void hoverstart()
    {
        transform.localScale = Vector3.one * 1.1f;
    }
    public void hoverend()
    {
        transform.localScale = Vector3.one;
    }
    public void clickstart()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        mr.material.color = Color.grey;
    }
    public void clickend()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        mr.material.color = Color.white;
    }
    public void click()
    {
        SceneManager.LoadScene("Game Scene");
    }
    
}