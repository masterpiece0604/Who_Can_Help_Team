using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UseCook : MonoBehaviour
{
    public Text OwnItem;
    private string OwnText;
    public GameObject num;
    public GameObject btns;
    public Item Rabbit;
    public Item Monkey;
    public Item Pig;
    public Item Bat;
    public Item CookedRabbit;
    public Item CookedMonkey;
    public Item CookedPig;
    public Item CookedBat;
    public Item thisItem;
    private int InputNum;
    private string Make;
    public Text GetInputNum;
    private string SaveInputNum;
    public Inventory playerInventory;
    [Header("烹飪用具對話")]
    public GameObject bowl;
    public float letterPause = 0.1f;
    private string word;
    private bool textFinished;

    private void Start()
    {
        SaveInputNum = GetInputNum.text;
        OwnText = OwnItem.text;
        StartCoroutine(SetTextUI());
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            CloseUI.Open_UI();
            Destroy(bowl);
        }

    }

    public void Cook_Rabbit()
    {
        if (textFinished)
        {
            num.SetActive(true);
            btns.SetActive(false);
            OwnItem.text = "兔兔這麼可愛，怎麼可以吃兔兔QAQ，你有兔兔肉 " + Rabbit.itemHold + "個，請問要煮幾份呢？";
            StartCoroutine(SetTextUI());
            Make = "熟的兔兔肉";
        }

    }
    public void Cook_Monkey()
    {
        if (textFinished)
        {
            num.SetActive(true);
            btns.SetActive(false);
            OwnItem.text = "你有獼猴肉 " + Monkey.itemHold + "個，請問要煮幾份呢？";
            StartCoroutine(SetTextUI());
            Make = "熟的獼猴肉";
        }
    }
    public void Cook_Pig()
    {
        if (textFinished)
        {
            num.SetActive(true);
            btns.SetActive(false);
            OwnItem.text = "你有山豬肉 " + Pig.itemHold + "個，請問要煮幾份呢？";
            StartCoroutine(SetTextUI());
            Make = "熟的山豬肉";
        }
    }
    public void Cook_Bat()
    {
        if (textFinished)
        {
            num.SetActive(true);
            btns.SetActive(false);
            OwnItem.text = "你有蝙蝠肉 " + Bat.itemHold + "個，請問要煮幾份呢？";
            StartCoroutine(SetTextUI());
            Make = "熟的蝙蝠肉";
        }
    }

    public void ClickNum()
    {
        if (textFinished)
        {
            num.SetActive(false);
            if (GetInputNum.text != SaveInputNum)
            {
                InputNum = int.Parse(GetInputNum.text);


                switch (Make)
                {

                    case "熟的兔兔肉":
                        if (InputNum <= Rabbit.itemHold)
                        {
                            Rabbit.itemHold -= InputNum;
                            thisItem = CookedRabbit;
                            AddNewItem();
                            OwnItem.text = "獲得" + Make + InputNum + "個";
                            StartCoroutine(SetTextUI());
                        }
                        else
                        {
                            OwnItem.text = "材料不夠哦！";
                            StartCoroutine(SetTextUI());
                        }
                        break;
                    case "熟的獼猴肉":
                        if (InputNum <= Monkey.itemHold)
                        {
                            Monkey.itemHold -= InputNum;
                            thisItem = CookedMonkey;
                            AddNewItem();
                            OwnItem.text = "獲得" + Make + InputNum + "個";
                            StartCoroutine(SetTextUI());
                        }
                        else
                        {
                            OwnItem.text = "材料不夠哦！";
                            StartCoroutine(SetTextUI());
                        }
                        break;
                    case "熟的山豬肉":
                        if (InputNum <= Pig.itemHold)
                        {
                            Pig.itemHold -= InputNum;
                            thisItem = CookedPig;
                            AddNewItem();
                            OwnItem.text = "獲得" + Make + InputNum + "個";
                            StartCoroutine(SetTextUI());
                        }
                        else
                        {
                            OwnItem.text = "材料不夠哦！";
                            StartCoroutine(SetTextUI());
                        }
                        break;
                    case "熟的蝙蝠肉":
                        if (InputNum <= Bat.itemHold)
                        {
                            Bat.itemHold -= InputNum;
                            thisItem = CookedBat;
                            AddNewItem();
                            OwnItem.text = "獲得" + Make + InputNum + "個";
                            StartCoroutine(SetTextUI());
                        }
                        else
                        {
                            OwnItem.text = "材料不夠哦！";
                            StartCoroutine(SetTextUI());
                        }
                        break;
                }

            }
            else
            {
                OwnItem.text = "你有想換東西嗎???(握拳)";
                StartCoroutine(SetTextUI());
            }
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
        CloseUI.Open_UI();
        Destroy(bowl);
    }
    IEnumerator SetTextUI()
    {
        word = OwnItem.text;
        OwnItem.text = "";
        textFinished = false;

        foreach (char letter in word.ToCharArray())
        {
            OwnItem.text += letter;
            yield return new WaitForSeconds(letterPause);
        }
        textFinished = true;
    }
}
