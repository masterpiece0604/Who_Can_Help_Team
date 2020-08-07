using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NPCTalking : MonoBehaviour
{
    [Header("NPC說話文字框")]
    public Text NPC_Says;
    [Header("第一次到便利店文字文件")]
    public TextAsset textFile1;
    public int index;
    public NPC NPC;
    public ctrllor1 ctrllor1;
    public float textSpeed;
    public bool textFinished;
    bool cancelTyping;

    public List<string> textList = new List<string>();

    private void Awake()
    {
        GetTextFromFile(textFile1);
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
        if (Input.GetKeyDown(KeyCode.F) || Input.GetMouseButtonDown(0))
        {
            if (index == textList.Count)
            {
                ctrllor1.NPC = false;
                NPC.UICanvasGroup.alpha = 1;
                NPC.talkingField.SetActive(false);
                index = 2;
                return;
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
