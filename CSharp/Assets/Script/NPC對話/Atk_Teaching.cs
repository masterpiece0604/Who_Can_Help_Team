using UnityEngine;

public class Atk_Teaching : MonoBehaviour
{
    [Header("攻擊教學對話框畫布")]
    public GameObject AtkTeachingCanvas;
    public ctrllor1 ctrllor1;
    public GameObject UI;
    //public NPC_Teaching NPC_Teaching;

    public bool a;
    bool b;

    private void Start()
    {
        b = true;
    }

    private void Update()
    {
        if (a && b)
        {
            AtkTeachingCanvas.SetActive(true);
            ctrllor1.NPC = true;
            a = false;
            b = false;
            UI.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.GetComponent<Collider>().tag == "Player" && b == true)
        {
            a = !a;
            ctrllor1.Sstand();
        }
    }
}
