using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NPC_Teaching2 : MonoBehaviour
{
    public Text NPC_Says;

    [Header("文字文件")]
    public TextAsset textFile;
    public int index;
    public NPC NPC;
    public ctrllor1 ctrllor1;
    public float textSpeed;
    public bool textFinished;
    bool cancelTyping;
    public GameManager GM;
    


    //public Atk_Teaching Atk_Teaching;

    public List<string> textList = new List<string>();


    private void Awake()
    {
        GetTextFromFile(textFile);
    }

    private void OnEnable()
    {
        //NPC_Says.text = textList[index];
        //index++;
        
        StartCoroutine(SetTextUI());

        //print("456");
    }

    private void Start()
    {
        index = 2;
        //StartCoroutine(SetTextUI());
        gameObject.SetActive(false);
        //Atk_Teaching.AtkTeachingCanvas.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)|| Input.GetMouseButtonDown(0))
        {
            if (index == textList.Count)
            {
                ctrllor1.NPC = false;
                NPC.UI.SetActive(true);
                NPC.talking = false;
                NPC.talkingField.SetActive(false);
                gameObject.SetActive(false);
                index = 2;

                return;
            }
        }
        
        /*if (Input.GetKeyDown(KeyCode.F) && textFinished==true)
        {
            //NPC_Says.text = textList[index];
            //index++;
            /*switch (textList[index])
            {
                case "A":
                    print("123");
                    index++;
                    break;
            }*/
        // StartCoroutine(SetTextUI());
        //}*/
        if (Input.GetKeyDown(KeyCode.F)||Input.GetMouseButtonDown(0))
        {
            if(textFinished && !cancelTyping)
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

        /*for (int i = 0; i < textList[index].Length; i++)
        {
            NPC_Says.text += textList[index][i];

            yield return new WaitForSeconds(textSpeed);
        }*/
        int letter = 0;
        while (!cancelTyping&& letter<textList[index].Length-1)
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
