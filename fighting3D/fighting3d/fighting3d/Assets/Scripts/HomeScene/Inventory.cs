using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    InventoryUI inventoryUI;

    public List<Item> items = new List<Item>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
       inventoryUI = GetComponent<InventoryUI>();
        inventoryUI.UpdateUI();
    }
    public void Add(Item item)
    {
        items.Add(item);
        inventoryUI.UpdateUI();
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        inventoryUI.UpdateUI();
    }
   
}











