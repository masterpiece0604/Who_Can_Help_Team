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
}
