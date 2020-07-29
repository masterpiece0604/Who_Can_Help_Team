using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseGrind : MonoBehaviour
{
    public Text OwnItem;
    public GameObject num;
    public GameObject btns;
    public Item MedicineA;
    public Item MedicineB;
    private int InputNum;
    private string Make;
    public Text GetInputNum;


    private void Start()
    {
        if(GetInputNum.text==null)
        print(GetInputNum.text);
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
        InputNum = int.Parse(GetInputNum.text);
        if (InputNum!=0)
        {
           
            btns.SetActive(false);
        
                switch (Make)
                        {

                            case "低級解毒藥": 
                                if(InputNum <= MedicineA.itemHold)
                                {
                                    OwnItem.text = "獲得" + Make + InputNum + "個";
                                }
                                else
                                {
                                    OwnItem.text = "材料不夠哦！";
                                }
                                break;
                            case "中級解毒藥":
                                if (InputNum <= MedicineA.itemHold&& InputNum <= MedicineB.itemHold)
                                {
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
            OwnItem.text = "你有想換東西嗎???";
        }
        
       

    }
}
