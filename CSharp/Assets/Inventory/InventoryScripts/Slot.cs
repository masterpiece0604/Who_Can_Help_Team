using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item slotItem;
    public Image slotImage;
    public Text slotNum;

    public GameObject itemInSlot;

    public void ItemDescription()
    {
        InventoryManager.UpdateItemInfo(slotItem.itemInfo);
    }

    public void SetupSlot(Item item)
    {
        if(item == null)
        {
            itemInSlot.SetActive(false);
            return;
        }

        slotImage.sprite = item.itemImage;
        slotNum.text = item.itemHold.ToString();
    }

   
}
