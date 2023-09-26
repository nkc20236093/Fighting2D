using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "New Item" , menuName = "ScriptableObject/Create Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";

    public Sprite icon = null;
    //public Text itemName = null;
    //public Button button = null;    2çsÇ¢ÇÁÇ»Ç¢


    public string itemName = null;


}
