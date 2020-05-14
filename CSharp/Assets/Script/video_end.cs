using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;


public class video_end : MonoBehaviour
{
    public VideoPlayer Movie_;

    void Start()
    {
        // VP = transform.GetComponent<VideoPlayer>();
        //VP.loopPointReached += EndReached;
        InvokeRepeating("CheckMovie", 3f, 0.1f);

    }

    void CheckMovie()
    {
        if (Movie_.isPlaying == false)
        {
            SceneManager.LoadScene("開始介面");
        }
    }


    public void Nextscene()
    {
        // Application.LoadLevel("場景名稱");
        // Application.LoadLevel(場景名稱ID);
        // Application.loadLevel讀取當前關卡名稱
        // Application.LoadLevel(Application.loadLevel);重新遊戲

        SceneManager.LoadScene("開始介面");
    }
}
