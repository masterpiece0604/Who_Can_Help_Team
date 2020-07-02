using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject talkingField;
    public bool talking;
    public bool a;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(10, 11);
        talkingField.gameObject.SetActive(talking);
    }

    // Update is called once per frame
    void Update()
    {
        if (a==true && Input.GetKeyDown(KeyCode.F))
        {
            talking = !talking;
            if (talking)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
            talkingField.gameObject.SetActive(talking);
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
