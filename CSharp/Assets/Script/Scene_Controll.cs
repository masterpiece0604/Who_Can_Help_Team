using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Controll : MonoBehaviour
{
    public GameObject[] MenuButton;
    public GameObject ChooseImage;
    public bool buttons;
    public bool ChooseImage1;

    private void Start()
    {
        ChooseImage1 = true;
    }

    /// <summary>
    /// 滑鼠移入
    /// </summary>
    public void P_State()
    {
        ChooseImage1 = !ChooseImage1;
        buttons = !buttons;
        ChooseImage.gameObject.SetActive(ChooseImage1);
        MenuButton[0].gameObject.SetActive(buttons);
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
