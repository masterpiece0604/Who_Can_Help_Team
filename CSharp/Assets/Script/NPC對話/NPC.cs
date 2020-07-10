using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject talkingField;
    public bool talking;
    public bool a;
    public ctrllor1 ctrllor1;
    public float OldPlayerSpeed;
    public GameObject UI;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(10, 11);
        talkingField.gameObject.SetActive(talking);
        OldPlayerSpeed = ctrllor1.playerspeed;
        print(OldPlayerSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (a==true && Input.GetKeyDown(KeyCode.F))
        {
            talking = !talking;
            talkingField.gameObject.SetActive(talking);
            
            if (talking==true)
            {
                ctrllor1.NPC = true;
                ctrllor1.Sstand();
                UI.SetActive(false);
            }
            else if(talking==false)
            {
                ctrllor1.NPC = false;
                UI.SetActive(true);
            }
            
            
        }
            
    }
    
    private void OnTriggerEnter(Collider hit)
    {
        if(hit.GetComponent<Collider>().tag=="Player")
            a = !a;
    }

    private void OnTriggerExit(Collider hit)
    {
        if (hit.GetComponent<Collider>().tag == "Player")
            a = !a;
    }
    
    /*public void FtoTalk()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            talking = !talking;
            talkingField.gameObject.SetActive(talking);
        }
    }*/
}
