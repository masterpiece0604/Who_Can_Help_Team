﻿using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("暫停圖")]
    public GameObject pause;
    [Header("暫停文字")]
    public GameObject pause1;
    [Header("存檔文字")]
    public GameObject save;
    [Header("訊息對話框")]
    public GameObject log;

    public NPC NPC;

    public bool onOpenPause;
    public bool onOpenPause1;
    public bool clickSave;
    public bool logState;

    private void Start()
    {
        onOpenPause1=true;
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
            NPC.talkingField.SetActive(false);
        }
        else
        {
            Time.timeScale = 1;
            NPC.talkingField.SetActive(true);
        }
        pause.gameObject.SetActive(onOpenPause);
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
            log.gameObject.transform.position = new Vector3(-190, 205, transform.position.z);
        }
        if (logState == true)
        {
            log.gameObject.transform.position = new Vector3(242.5f, 205, transform.position.z);
        }
    }

}
