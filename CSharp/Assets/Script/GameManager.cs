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

    // 關UI
    public Atk_Teaching Player_atk_teaching;

    // 猴子物件
    public GameObject Monkey1;
    // 任務2對話框
    public GameObject mission2;
    // 判定猴子是否活著
    bool Monkey1Alive;

    // 猴子物件
    public GameObject Monkey2;
    // 任務2對話框
    public GameObject mission3;
    // 判定猴子是否活著
    bool Monkey2Alive;

    private void Start()
    {
        onOpenPause1 = true;
        logState = false;
        MoveLogMsg();
        Monkey1Alive = true;
        Monkey2Alive = true;
    }

    private void Update()
    {
        NpcTalkOnOpen = NPC.talking;
        Monkey1IsDead();
        Monkey2IsDead();
    }

    /// <summary>
    /// 猴子1死亡
    /// </summary>
    public void Monkey1IsDead()
    {
        if(Monkey1 == null && Monkey1Alive == true)
        {
            mission2.SetActive(true);
            Monkey1Alive = false;

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
