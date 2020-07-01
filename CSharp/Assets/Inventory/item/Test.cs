using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Inventory inven;

    private void Start()
    {
        print(inven.itemList[0].itemInfo);
    }
}
