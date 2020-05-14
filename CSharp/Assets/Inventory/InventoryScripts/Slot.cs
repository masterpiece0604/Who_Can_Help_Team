using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item slotItem;
    public Image slotImage;
    public Text slotNum;
    public Text itemInformation;
   

    public GameObject itemInSlot;

    private void Start()
    {
        itemInformation.gameObject.SetActive(false);
    }

    public void mouseClick()
    {
        itemInformation.gameObject.SetActive(true);
        //InventoryManager.UpdateItemInfo(slotItem.itemInfo);
    }
    private void OnMouseExit()
    {
        itemInformation.gameObject.SetActive(false);
    }

    /*public void ItemDescription()
    {
        InventoryManager.UpdateItemInfo(slotItem.itemInfo);
    }*/


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
