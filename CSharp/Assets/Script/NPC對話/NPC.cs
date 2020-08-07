using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [Header("第一次到便利店畫布")]
    public GameObject talkingField;
    [Header("非第一次到便利店畫布")]
    public GameObject talkingField1;
    public bool a;
    public ctrllor1 ctrllor1;
    public float OldPlayerSpeed;
    public GameObject UI;
    public CanvasGroup UICanvasGroup;
    public bool firstTime;

    void Start()
    {
        OldPlayerSpeed = ctrllor1.playerspeed;
        UICanvasGroup = UI.GetComponent<CanvasGroup>();
        firstTime = true;
    }

    void Update()
    {
        if (a == true && Input.GetKeyDown(KeyCode.F) && firstTime)
        {
            talkingField.SetActive(true);
            ctrllor1.NPC = true;
            ctrllor1.Sstand();
            UICanvasGroup.alpha = 0;
            firstTime = false;
        }
        if(a == true && Input.GetKeyDown(KeyCode.F) && firstTime == false)
        {
            talkingField1.SetActive(true);
            ctrllor1.NPC = true;
            ctrllor1.Sstand();
            UICanvasGroup.alpha = 0;
        }
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.GetComponent<Collider>().tag == "Player")
            a = !a;
    }

    private void OnTriggerExit(Collider hit)
    {
        if (hit.GetComponent<Collider>().tag == "Player")
            a = !a;
    }
}
