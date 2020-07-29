using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pick : MonoBehaviour
{
    [Header("存放主角物件")]
    public GameObject player;

    [Header("可採集距離")]
    public float dis;

    [Header("採集時間")]
    public float pickTime;

    [Header("採集時間條")]
    public Image Time;

    [Header("採集的物品")]
    public Item thisItem;

    [Header("採集的數量")]
    public int ItemNum = 1;

    public Inventory playerInventory;

    //按下F的時間
    float FTime;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        PickDis();
    }

    public void PickDis()
    {
       
        if (Input.GetKey(KeyCode.F) && Vector3.Distance(transform.position,player.transform.position)<dis)
        {

            FTime += 0.1f;
            Time.fillAmount = FTime/6;
            if(Time.fillAmount==1f)
            {
                FTime = 0;
                GetProps();

            }
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            FTime = 0;
            Time.fillAmount = FTime / 6;
        }
    }

    public void GetProps()
    {
        if (!playerInventory.itemList.Contains(thisItem))
        {
            // playerInventory.itemList.Add(thisItem);
            // InventoryManager.CreateNewItem(thisItem);
            for (int i = 0; i < playerInventory.itemList.Count; i++)
            {
                if (playerInventory.itemList[i] == null)
                {
                    playerInventory.itemList[i] = thisItem;
                    thisItem.itemHold += ItemNum;
                    break;
                }
            }
        }
        else
        {
            thisItem.itemHold += ItemNum;
        }

        InventoryManager.RefreshItem();
        Destroy(gameObject);
    }

}
