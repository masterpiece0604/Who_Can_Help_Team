using UnityEngine;
using UnityEngine.UI;

public class UseGrind : MonoBehaviour
{
    public Text OwnItem;
    private string OwnText;
    public GameObject num;
    public GameObject btns;
    public Item MedicineA;
    public Item MedicineB;
    public Item Low_Medicine;
    public Item Mid_Medicine;
    public Item thisItem;
    private int InputNum;
    private string Make;
    public Text GetInputNum;
    private string SaveInputNum;
    public Inventory playerInventory;
    [Header("研磨缽對話")]
    public GameObject bowl;


    private void Start()
    {
        SaveInputNum = GetInputNum.text;
        OwnText = OwnItem.text;
    }

    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.F))
        {
            Destroy(bowl);          
        }
        
    }

    public void LowMedicine()
    {
        num.SetActive(true);
        btns.SetActive(false);
        OwnItem.text = "製造低級解毒藥需要藥草A，你有藥草A " + MedicineA.itemHold + "個，請問要做幾個呢？";
        Make = "低級解毒藥";
    }

    public void MidMedicine()
    {
        num.SetActive(true);
        btns.SetActive(false);
        OwnItem.text = "製造中級解毒藥需要藥草A、藥草B，你有藥草A " +MedicineA.itemHold + "個、你有藥草B " + MedicineB.itemHold + "個，請問要做幾個呢？";
        Make = "中級解毒藥";
    }

    public void ClickNum()
    { 
        num.SetActive(false);
        if (GetInputNum.text != SaveInputNum)
        {
            InputNum = int.Parse(GetInputNum.text);
            

                switch (Make)
                {

                    case "低級解毒藥":
                        if (InputNum <= MedicineA.itemHold)
                        {
                            MedicineA.itemHold -= InputNum;
                            thisItem = Low_Medicine;
                            OwnItem.text = "獲得" + Make + InputNum + "個";
                            AddNewItem();
                        }
                        else
                        {
                            OwnItem.text = "材料不夠哦！";
                        }
                        break;
                    case "中級解毒藥":
                        if (InputNum <= MedicineA.itemHold && InputNum <= MedicineB.itemHold)
                        {
                            MedicineA.itemHold -= InputNum;
                            MedicineB.itemHold -= InputNum;
                            thisItem = Mid_Medicine;
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
    public void Close()
    {
        Destroy(bowl);
    }

    
}
