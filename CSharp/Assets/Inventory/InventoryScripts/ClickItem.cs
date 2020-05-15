using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickItem : MonoBehaviour
{
    public Image item_Information;
    bool controlText = false;
    public Item slotItem;
    public GameObject itemInSlot;
    static InventoryManager instance;



    private void Start()
    {
        item_Information.gameObject.SetActive(false);

        
    }

    public void mouseClick()
    {
        
        controlText = !controlText;
        
           /* for (int i = 0; i < instance.myBag.itemList.Count; i++)
            {
                //CreateNewItem(instance.myBag.itemList[i]);

                instance.slots[i].GetComponent<Slot>().SetupSlot(instance.myBag.itemList[i]);
                
            }*/
        
        item_Information.gameObject.SetActive(controlText);
        InventoryManager.UpdateItemInfo(slotItem.itemInfo);
        print(slotItem.itemInfo);
    }

    public void SetupSlot(Item item)
    {
        if (item == null)
        {
            itemInSlot.SetActive(false);
            return;
        }

    }
    

}
