using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickItem : MonoBehaviour
{
    static ClickItem instance1;
    bool controlText = false;
    [Header("物品介紹")]
    public Image Item_Information;
    public Text ItemInfoText;
    public string slotInfo;
    public Transform originalParent;

    /*private void OnEnable()
    {
        instance1.ItemInfoText.text = "";
    }*/

    void Update()
    {
        Item_Information.gameObject.SetActive(controlText);
        //InventoryManager.UpdateItemInfo(slotItem.itemInfo);
    }
    

    public void clickItem()
    {
        controlText = !controlText;
        //InventoryManager.UpdateItemInfo(slotInfo);

        transform.SetParent(transform.parent.parent, true);
        if (controlText == false)
        {
            originalParent = transform.parent;
        }

        //ItemInfoText.text = (slotItem.itemInfo);
        //UpdateItemInfo(slotItem.itemInfo);
        //print(slotItem.itemInfo);
    }
    

    public static void UpdateItemInfo(string itemDescription)
    {
        instance1.ItemInfoText.text = itemDescription;
        //print(instance.itemInformation.text);
    }

    

}
