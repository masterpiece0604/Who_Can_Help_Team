using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Controll : MonoBehaviour
{
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
