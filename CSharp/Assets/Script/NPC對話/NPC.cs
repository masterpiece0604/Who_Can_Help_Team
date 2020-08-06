using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [Header("NPC對話框畫布")]
    public GameObject talkingField;
    //public bool talking;
    public bool a;
    public ctrllor1 ctrllor1;
    public float OldPlayerSpeed;
    public GameObject UI;
    public CanvasGroup UICanvasGroup;

    void Start()
    {
        OldPlayerSpeed = ctrllor1.playerspeed;
        UICanvasGroup = UI.GetComponent<CanvasGroup>();
    }


    void Update()
    {
        if (a == true && Input.GetKeyDown(KeyCode.F))
        {
            //talking = true;
            talkingField.SetActive(true);

            //if (talking == true)
            //{
            ctrllor1.NPC = true;
            ctrllor1.Sstand();
            UICanvasGroup.alpha = 0;
            //}
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
