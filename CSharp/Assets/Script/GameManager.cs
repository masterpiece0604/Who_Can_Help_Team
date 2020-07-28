using UnityEngine;
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
    public GameObject LogIsOpen;
    public GameObject LogIsClosed;

    public NPC NPC;
    public PauseUIManager PauseUIManager;

    public bool onOpenPause;
    public bool onOpenPause1;
    public bool clickSave;
    public bool logState;
    bool NpcTalkOnOpen;

    // 猴子物件
    public GameObject Monkey;
    // 任務2對話框
    public GameObject mission2;
    bool MonkeyAlive;
    

    private void Start()
    {
        onOpenPause1 = true;
        logState = false;
        MoveLogMsg();
        MonkeyAlive = true;
    }

    private void Update()
    {
        NpcTalkOnOpen = NPC.talking;
        MonkeyIsDead();
    }

    /// <summary>
    /// 猴子死亡
    /// </summary>
    public void MonkeyIsDead()
    {
        if(Monkey == null && MonkeyAlive == true)
        {
            mission2.SetActive(true);
            MonkeyAlive = false;
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
            NPC.talkingField.SetActive(false);
        }
        else
        {
            Time.timeScale = 1;
            NPC.talkingField.SetActive(NpcTalkOnOpen);
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
