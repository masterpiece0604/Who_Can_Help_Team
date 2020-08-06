﻿using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("暫停圖")]
    public GameObject pause;
    [Header("暫停文字")]
    public GameObject pause1;
    [Header("存檔文字")]
    public GameObject save;
    [Header("訊息對話框")]
    public GameObject LogIsOpen;
    public GameObject LogIsClosed;

    public NPC npc;
    public PauseUIManager PauseUIManager;

    public bool onOpenPause;
    public bool onOpenPause1;
    public bool clickSave;
    public bool logState;

    // 猴子物件
    public GameObject Monkey1;
    [Header("任務2對話框")]
    public GameObject mission2;
    // 不讓對話重複開啟
    bool Monkey1Alive;

    // 猴子物件
    public GameObject Monkey2;
    [Header("任務3對話框")]
    public GameObject mission3;
    // 不讓對話重複開啟
    bool Monkey2Alive;
    // 關UI
    [SerializeField]
    GameObject UI;
    [SerializeField]
    ctrllor1 Ctrllor1;

    // 樹、石頭、藥草物件
    public GameObject tree, stone, herbs;
    [Header("任務4對話框")]
    public GameObject mission4;
    [Header("研磨砵")]
    public Item MedicineMachine;
    // 不讓對話重複開啟
    bool mission4done;
    
    [Header("低級藥草Item")]
    public Item lowMedesom;
    [Header("小木屋Item")]
    public Item Hub;
    [Header("任務五對話框")]
    public GameObject mission5;
    // 不讓對話重複開啟
    bool mission5talkingfild;

    [Header("過完夜任務")]
    public GameObject mission6;
    // 不讓對話重複開啟
    bool mission6dontRepeat;

    public CanvasGroup UICanvasG;

    private void Start()
    {
        onOpenPause1 = true;
        logState = false;
        MoveLogMsg();
        Monkey1Alive = true;
        Monkey2Alive = true;
        mission4done = false;
        mission5talkingfild = true;
        mission6dontRepeat = true;
        UICanvasG = UI.GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        Monkey1IsDead();
        Monkey2IsDead();
        TreeAndStone();
        IsMade();
        NextDay();
    }

    /// <summary>
    /// 猴子1死亡
    /// </summary>
    public void Monkey1IsDead()
    {
        if (Monkey1 == null && Monkey1Alive == true)
        {
            mission2.SetActive(true);
            Monkey1Alive = false;
            UICanvasG.alpha = 0;
            Ctrllor1.NPC = true;
        }
    }

    /// <summary>
    /// 猴子2死亡
    /// </summary>
    public void Monkey2IsDead()
    {
        if (Monkey2 == null && Monkey2Alive == true)
        {
            mission3.SetActive(true);
            Monkey2Alive = false;
            UICanvasG.alpha = 0;
            Ctrllor1.NPC = true;
        }
    }

    /// <summary>
    /// 砍樹挖礦採草完成後執行
    /// </summary>
    public void TreeAndStone()
    {
        if (tree == null && stone == null && herbs == null && mission4done == false)
        {
            mission4.SetActive(true);
            mission4done = true;
            UICanvasG.alpha = 0;
            Ctrllor1.NPC = true;
            giveMedicineMachine();
        }
    }
    // 給研磨砵
    public void giveMedicineMachine()
    {
        MedicineMachine.itemHold += 1;
    }

    /// <summary>
    /// 完成製作
    /// </summary>
    public void IsMade()
    {
        if (lowMedesom.itemHold == 1 && mission5talkingfild == true)
        {
            if (GameObject.FindGameObjectWithTag("研磨砵") == null)
            {
                mission5.SetActive(true);
                mission5talkingfild = false;
                UICanvasG.alpha = 0;
                // UI.SetActive(false);
                Ctrllor1.NPC = true;
                giveHub();
            }
        }
    }
    // 給小木屋
    public void giveHub()
    {
        Hub.itemHold += 1;
    }

    /// <summary>
    /// 隔天
    /// </summary>
    public void NextDay()
    {
        if(time_count.timer_date == 2 && mission6dontRepeat == true)
        {
            print("GM抓的時間" + time_count.timer_date);
            mission6.SetActive(true);
            mission6dontRepeat = false;
            UICanvasG.alpha = 0;
            // UI.SetActive(false);
            Ctrllor1.NPC = true;
        }
    }

    /// <summary>
    /// 遊戲中按暫停彈出暫停視窗
    /// </summary>
    public void Pause_When_Gaming()
    {
        onOpenPause = !onOpenPause;
        if (onOpenPause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        pause.gameObject.SetActive(onOpenPause);
        PauseUIManager.onPause = true;
        PauseUIManager.onSaveGame = false;
    }
    /// <summary>
    /// 按下設定的Save
    /// </summary>
    public void Press_Save()
    {
        onOpenPause1 = !onOpenPause1;
        clickSave = !clickSave;
        pause1.gameObject.SetActive(onOpenPause1);
        save.gameObject.SetActive(clickSave);
    }
    /// <summary>
    /// 訊息彈窗
    /// </summary>
    public void MoveLogMsg()
    {
        logState = !logState;
        if (logState == false)
        {
            LogIsOpen.SetActive(false);
            LogIsClosed.SetActive(true);
        }
        if (logState == true)
        {
            LogIsOpen.SetActive(true);
            LogIsClosed.SetActive(false);
        }
    }
}
