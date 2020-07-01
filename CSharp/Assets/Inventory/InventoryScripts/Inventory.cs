using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Invertory", menuName = "Inventory/New Invertory")]

public class Inventory : ScriptableObject
{
    public List<Item> itemList = new List<Item>();
}

