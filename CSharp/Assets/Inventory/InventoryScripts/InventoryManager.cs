using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance;

    public Inventory myBag;
    public Inventory Eqi;
    public Inventory Use;
    public Inventory Make;
    public GameObject slotGrid, slotGridEQI, slotGridUSE, slotGridMAKE ;
   
    //public Slot slotPrefab;
    public GameObject emptySlot;
    public GameObject Bag;
    public Text itemInformation;

    /*public GameObject itemInfoImage;
    bool onOpenInfoImage;*/

    /*[Header("物品介紹")]
    public Image Item_Information;
    public Slot slot;
    public bool controlText = false;*/

    public List<GameObject> slots = new List<GameObject> ();



    /*void Update()
    {
        Item_Information.gameObject.SetActive(controlText);
        //InventoryManager.UpdateItemInfo(slotItem.itemInfo);
        Debug.Log(controlText);
    }

    public void clickItem2()
    {

        controlText = !controlText;
    }*/

    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this; 
    }
    

    /*private void Update()
    {
        itemInfoImage.SetActive(onOpenInfoImage);
    }

    public void InfoImageControll()
    {
        onOpenInfoImage = !onOpenInfoImage;
        var InfoImagePosition = new Vector3(Input.mousePosition.x + 5, Input.mousePosition.y + 5, Input.mousePosition.z);
        itemInfoImage.transform.position = InfoImagePosition;
        
    }*/
    

    private void OnEnable()
    {
        RefreshItem();
        instance.itemInformation.text = null;
    }

    public static void UpdateItemInfo(string itemDescription)
    {
        instance.itemInformation.text = itemDescription;
    }
    
    /*public static void CreateNewItem(Item item)
    {
        Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.itemImage;
        newItem.slotNum.text = item.itemHold.ToString();
    }*/

    public static void RefreshItem()
    {

        for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            if (instance.slotGrid.transform.childCount == 0)
                break;
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
            instance.slots.Clear();
        }

        for (int i = 0; i < instance.myBag.itemList.Count; i++)
        {
            //CreateNewItem(instance.myBag.itemList[i]);
            instance.slots.Add(Instantiate(instance.emptySlot));
            instance.slots[i].transform.SetParent(instance.slotGrid.transform);
            instance.slots[i].GetComponent<Slot>().slotID = i;
            instance.slots[i].GetComponent<Slot>().SetupSlot(instance.myBag.itemList[i]);
        }

        for (int i = 0; i < instance.slotGridEQI.transform.childCount; i++)
        {
            if (instance.slotGridEQI.transform.childCount == 0)
                break;
            Destroy(instance.slotGridEQI.transform.GetChild(i).gameObject);
            instance.slots.Clear();
        }

        for (int i = 0; i < instance.Eqi.itemList.Count; i++)
        {
            //CreateNewItem(instance.myBag.itemList[i]);
            instance.slots.Add(Instantiate(instance.emptySlot));
            instance.slots[i].transform.SetParent(instance.slotGridEQI.transform);
            instance.slots[i].GetComponent<Slot>().slotID = i;
            instance.slots[i].GetComponent<Slot>().SetupSlot(instance.Eqi.itemList[i]);
        }

        for (int i = 0; i < instance.slotGridUSE.transform.childCount; i++)
        {
            if (instance.slotGridUSE.transform.childCount == 0)
                break;
            Destroy(instance.slotGridUSE.transform.GetChild(i).gameObject);
            instance.slots.Clear();
        }

        for (int i = 0; i < instance.Use.itemList.Count; i++)
        {
            //CreateNewItem(instance.myBag.itemList[i]);
            instance.slots.Add(Instantiate(instance.emptySlot));
            instance.slots[i].transform.SetParent(instance.slotGridUSE.transform);
            instance.slots[i].GetComponent<Slot>().slotID = i;
            instance.slots[i].GetComponent<Slot>().SetupSlot(instance.Use.itemList[i]);
        }

        for (int i = 0; i < instance.slotGridMAKE.transform.childCount; i++)
        {
            if (instance.slotGridMAKE.transform.childCount == 0)
                break;
            Destroy(instance.slotGridMAKE.transform.GetChild(i).gameObject);
            instance.slots.Clear();
        }

        for (int i = 0; i < instance.Make.itemList.Count; i++)
        {
            //CreateNewItem(instance.myBag.itemList[i]);
            instance.slots.Add(Instantiate(instance.emptySlot));
            instance.slots[i].transform.SetParent(instance.slotGridMAKE.transform);
            instance.slots[i].GetComponent<Slot>().slotID = i;
            instance.slots[i].GetComponent<Slot>().SetupSlot(instance.Make.itemList[i]);
        }
        instance.Bag.GetComponent<BagAssign>().reassign();
    }



}
