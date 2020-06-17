using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene_Controll : MonoBehaviour
{
    public GameObject[] buttons;
    public GameObject ChooseImage;

    /// <summary>
    /// 滑鼠移入
    /// </summary>
    public void Enter_0()
    {
        ChooseImage.gameObject.transform.position = buttons[0].transform.position;
    }

    public void Enter_1()
    {
        ChooseImage.gameObject.transform.position = buttons[1].transform.position;
    }

    public void Enter_2()
    {
        ChooseImage.gameObject.transform.position = buttons[2].transform.position;
    }

    public void Enter_3()
    {
        ChooseImage.gameObject.transform.position = buttons[3].transform.position;
    }

    public void Enter_4()
    {
        ChooseImage.gameObject.transform.position = buttons[4].transform.position;
    }

    public void New_Game()
    {
        SceneManager.LoadScene("動起來測試");
    }

    public void press_anykey()
    {
        SceneManager.LoadScene("開場動畫");
    }

    public void skip_animetion()
    {
        SceneManager.LoadScene("開始介面");
    }
    
    public void Guild()
    {
        SceneManager.LoadScene("新手教學關卡");
    }

    public void StartUI_Option()
    {
        SceneManager.LoadScene("開始介面的設定");
    }

    public void LoadingGame()
    {
        SceneManager.LoadScene("讀取進度");
    }

    public void Difficalty()
    {
        SceneManager.LoadScene("困難度"); 
    }

    /*public void HotKey()
    {
        SceneManager.LoadScene("按鍵設定");
    }*/

    

    #region 遊戲關閉
    public void Quit()
    {
        // 輸出成遊戲執行檔才可以進行測試
        Application.Quit();
    }
    #endregion
}
