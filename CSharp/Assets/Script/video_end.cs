using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;


public class video_end : MonoBehaviour
{
    VideoPlayer VP = new VideoPlayer();

    void Start()
    {
        VP = transform.GetComponent<VideoPlayer>();
        VP.loopPointReached += EndReached;

    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("開始介面");
    }

    public void starter()
    {
        SceneManager.LoadScene("開始介面");
    }
}
