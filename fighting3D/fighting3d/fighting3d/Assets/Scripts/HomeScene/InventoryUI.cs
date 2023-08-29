using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Transform slotsParent;

    Slot[] slots;




    // Start is called before the first frame update
    void Start()
    {
        slots = slotsParent.GetComponentsInChildren<Slot>();
    }

    // Update is called once per frame
    public void UpdateUI()
    {
        Debug.Log("UpdateUI");
        for(int i = 0; i <slots.Length; i++)
        {
            if(i < Inventory.instance.items.Count)
            {
                slots[i].AddItem(Inventory.instance.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }

        }
    }
}
