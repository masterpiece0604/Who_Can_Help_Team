using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseSuperMechine : MonoBehaviour
{
    public Text OwnItem;
    private string OwnText;
    public GameObject num;
    public GameObject btns;
    public Item MedicineA;
    public Item MedicineB;
    [Header("傳說中的解藥")]
    public Item MedicineC;
    public Item High_Medicine;
    public Item Legend_Medicine;
    public Item thisItem;
    private int InputNum;
    private string Make;
    public Text GetInputNum;
    private string SaveInputNum;
    public Inventory playerInventory;
    [Header("超級製藥機對話")]
    public GameObject Mechine;


    private void Start()
    {
        SaveInputNum = GetInputNum.text;
        OwnText = OwnItem.text;
    }

    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.F))
        {
            Destroy(Mechine);          
        }
        
    }

    public void HighMedicine()
    {
        num.SetActive(true);
        btns.SetActive(false);
        OwnItem.text = "製造高級解毒藥需要藥草A、藥草B，你有藥草A " + MedicineA.itemHold + "個、你有藥草B " + MedicineB.itemHold + "個，請問要做幾個呢？";
        Make = "高級解毒藥";
    }

    public void LegendMedicine()
    {
        num.SetActive(true);
        btns.SetActive(false);
        OwnItem.text = "製造傳說中的解藥需要傳說中的藥草，你有傳說中的藥草 " + MedicineC.itemHold+  "個，請問要做幾個呢？";
        Make = "傳說中的解藥";
    }

    public void ClickNum()
    { 
        num.SetActive(false);
        if (GetInputNum.text != SaveInputNum)
        {
            InputNum = int.Parse(GetInputNum.text);
            

                switch (Make)
                {

                    case "高級解毒藥":
                        if (InputNum <= MedicineA.itemHold && InputNum <= MedicineB.itemHold)
                        {
                            MedicineA.itemHold -= InputNum;
                            MedicineB.itemHold -= InputNum;
                            thisItem = High_Medicine;
                            AddNewItem();
                            OwnItem.text = "獲得" + Make + InputNum + "個";
                        }
                        else
                        {
                            OwnItem.text = "材料不夠哦！";
                        }
                        break;
                    case "傳說中的解藥":
                        if (InputNum <= MedicineC.itemHold)
                        {
                            MedicineC.itemHold -= InputNum;
                            thisItem = Legend_Medicine;
                            AddNewItem();
                            OwnItem.text = "獲得" + Make + InputNum + "個";
                        }
                        else
                        {
                            OwnItem.text = "材料不夠哦！";
                        }
                        break;
                }
         
        }
        else
            {
                OwnItem.text = "你有想換東西嗎???(很怒)";
            }

    }

    public void AddNewItem()
    {
        if (!playerInventory.itemList.Contains(thisItem))
        {
            playerInventory.itemList.Add(thisItem);
            thisItem.itemHold += InputNum;

        }
        else
        {

            thisItem.itemHold += InputNum;
        }
        InventoryManager.RefreshItem();

    }

    
}
