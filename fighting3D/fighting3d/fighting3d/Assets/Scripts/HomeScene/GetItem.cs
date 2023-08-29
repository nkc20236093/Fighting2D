using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetItem : MonoBehaviour
{
    public Item item;

    private void Start()
    {
        GetComponent<Image>().sprite = item.icon;
    }




    public void ItemGet()
    {
        //get item into the inventory  
        Inventory.instance.Add(item);

        
    }


}
