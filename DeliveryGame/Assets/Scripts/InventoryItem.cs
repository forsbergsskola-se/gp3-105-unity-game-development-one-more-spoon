using TMPro;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public int count;
    public TMP_Text countLabel;
    
    public void AddToInventory()
    {
            count++;
            gameObject.SetActive(true);
            countLabel.text = count.ToString();
            countLabel.gameObject.SetActive(true);
    }

    public void AddTextToinventory()
    {
        gameObject.SetActive(true);
    }
    
}

