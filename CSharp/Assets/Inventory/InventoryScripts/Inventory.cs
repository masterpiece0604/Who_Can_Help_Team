using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/New Invertory")]
=======
[CreateAssetMenu(fileName = "New Invertory", menuName = "Inventory/New Invertory")]
>>>>>>> 道具欄開發
public class Inventory : ScriptableObject
{
    public List<Item> itemList = new List<Item>();
}
