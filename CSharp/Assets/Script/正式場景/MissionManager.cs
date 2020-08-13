using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MissionManager : MonoBehaviour
{
    [Header("主角開場自言自語")]
    public GameObject selfTalking;



    public CanvasGroup UI;              // 關UI
    public NPC_Teaching NPC_teaching;   // 講話腳本
    bool isSelfTalk;                    // 避免對話框重複開啟

    private void Start()
    {
        isSelfTalk = false;
    }

    private void Update()
    {
        if(NPC_teaching.isStart == true && isSelfTalk == false)
        {
            UI.alpha = 0;
            selfTalking.SetActive(true);
            isSelfTalk = true;
        }
    }

}
