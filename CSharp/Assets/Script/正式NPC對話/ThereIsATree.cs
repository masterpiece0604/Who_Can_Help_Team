using UnityEngine;

public class ThereIsATree : MonoBehaviour
{
    [Header("主角走到樹旁邊畫布")]
    public GameObject walkToTree;
    bool walkToTreeTalk;
    bool asideTree;
    public ctrllor1 controll1;      // 控制走動
    public CanvasGroup UI;          // 控制UI開關

    private void Start()
    {
        asideTree = false;
        walkToTreeTalk = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Collider>().tag == "Player" && walkToTreeTalk == false)
        {
            walkToTree.SetActive(true);
            controll1.NPC = true;
            UI.alpha = 0;
            walkToTreeTalk = true;
        }
    }
}
