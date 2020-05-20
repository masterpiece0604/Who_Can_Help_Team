using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item slotItem;
    public Image slotImage;
    public Text slotNum;
    public string slotInfo;
    
    bool controlText = false;
    [Header("物品介紹")]
    public Image Item_Information;
    public Text ItemInfoText;
    


    public GameObject itemInSlot;


    /*private void OnMouseExit()
    {
        itemInformation.gameObject.SetActive(false);
    }*/

    /*public void ItemDescription()
    {
        InventoryManager.UpdateItemInfo(slotItem.itemInfo);
    }*/

    void Start()
    {
       
    }

    /*private void OnEnable()
    {
        ItemInfoText.text = "";
    }
    public void UpdateItemInfo(string itemDescription)
    {
        ItemInfoText.text = itemDescription;
        //print(instance.itemInformation.text);
    }*/

    void Update()
    {
        Item_Information.gameObject.SetActive(controlText);
        //InventoryManager.UpdateItemInfo(slotItem.itemInfo);
    }

    public void clickItem()
    {
        controlText = !controlText;
        InventoryManager.UpdateItemInfo(slotInfo);
        //ItemInfoText.text = (slotItem.itemInfo);
        //UpdateItemInfo(slotItem.itemInfo);
        //print(slotItem.itemInfo);
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
        slotInfo = item.itemInfo;
    }

   
}
