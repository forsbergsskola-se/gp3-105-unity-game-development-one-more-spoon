using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text questionText;
    //this method will be called when the yes button is clicked.
    public void OnYesButtonClick()
    {
        Debug.Log("You accepted the quest!");
    }

    public void OnNoButtonClick()
    {
        Debug.Log("OK, good luck finding another quest");
    }
}
