using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NPC_TeachingEnd : MonoBehaviour
{
    public Text NPC_Says;

    [Header("有獼猴肉")]
    public TextAsset textFile1;
    [Header("獼猴肉不夠")]
    public TextAsset textFile2;
    public int index;
    public NPC NPC;
    public ctrllor1 ctrllor1;
    public float textSpeed;
    public bool textFinished;
    bool cancelTyping;

    [Header("獼猴肉")]
    public Item MonkeyMeat;
    public GameObject SuccessCanvas;
    bool meatEnough;

    public Atk_Teaching Atk_Teaching;
    
    public List<string> textList = new List<string>();


    private void Awake()
    {

    }

    private void OnEnable()
    {
        StartCoroutine(SetTextUI());
    }

    private void Start()
    {
        index = 2;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (MonkeyMeat.itemHold >= 2)
        {
            meatEnough = true;
        }
        else
        {
            meatEnough = false;
        }

        if (Input.GetKeyDown(KeyCode.F) || Input.GetMouseButtonDown(0))
        {
            if (meatEnough)
            {
                GetTextFromFile(textFile1);
                if (index == textList.Count)
                {
                    NPC.talkingField.SetActive(false);
                    index = 2;
                    SuccessCanvas.SetActive(true);
                }
            }
            else
            {
                GetTextFromFile(textFile2);
                if (index == textList.Count)
                {
                    ctrllor1.NPC = false;
                    NPC.UICanvasGroup.alpha = 1;    // 開UI
                    // NPC.UI.SetActive(true);
                    // NPC.talking = false;
                    NPC.talkingField.SetActive(false);
                    index = 2;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.F) || Input.GetMouseButtonDown(0))
        {
            if (textFinished && !cancelTyping)
            {
                StartCoroutine(SetTextUI());
            }
            else if (!textFinished)
            {
                cancelTyping = !cancelTyping;
            }
        }
    }

    void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        index = 3;

        var lineData = file.text.Split('\n');

        foreach (var line in lineData)
        {
            textList.Add(line);
        }
    }

    IEnumerator SetTextUI()
    {
        textFinished = false;
        NPC_Says.text = "";
        string NPC1 = textList[0];

        if (textList[index] == textList[0])
        {
            index++;
        }

        int letter = 0;

        while (!cancelTyping && letter < textList[index].Length - 1)
        {
            NPC_Says.text += textList[index][letter];
            letter++;
            yield return new WaitForSeconds(textSpeed);
        }

        NPC_Says.text = textList[index];
        cancelTyping = false;
        textFinished = true;
        index++;
    }

}
