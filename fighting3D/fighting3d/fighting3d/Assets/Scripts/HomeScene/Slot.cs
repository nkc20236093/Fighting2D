using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    Item item;

    public Image icon;

    public GameObject button;


    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = newItem.icon;

    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
       // button.SetActive(false);
    }

     public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);
    }

   
}
