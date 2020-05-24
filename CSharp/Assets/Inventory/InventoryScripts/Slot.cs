using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    // 空格ID
    public int slotID;
    public Item slotItem;
    public Image slotImage;
    public Text slotNum;
    public string slotInfo;

    //public bool controlText = false;

    /*[Header("物品介紹")]
    public Image Item_Information;
    public Text ItemInfoText;*/

    public GameObject itemInSlot;


    /*public void ItemDescription()
    {
        InventoryManager.UpdateItemInfo(slotItem.itemInfo);
    }*/
    
    void Update()
    {
        //Item_Information.gameObject.SetActive(controlText);
        //InventoryManager.UpdateItemInfo(slotItem.itemInfo);
    }



    public void clickItem()
    {
        
        //controlText = !controlText;
        InventoryManager.UpdateItemInfo(slotInfo);


        //ItemInfoText.text = slotInfo;

        //transform.SetParent(transform.parent.parent, true);
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
