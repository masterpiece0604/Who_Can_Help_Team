using UnityEngine;
using UnityEngine.UI;

public class UseProp : MonoBehaviour
{
    private bool b;
    private float t1;
    private float t2;
    private Slot Propinfo;
    private Role_quality role_Quality;

    private void Start()
    {
        Propinfo = this.GetComponent<Slot>();
        role_Quality = GameObject.FindGameObjectWithTag("Player").GetComponent<Role_quality>();
    }

    private void Update()
    {
        if (b)
        {
            if(Input.GetMouseButtonDown(0))
            {
                t2 = Time.realtimeSinceStartup;
                if (t2 - t1 < 0.2)
                {
                    DubbleClick();
                }
                t1 = t2;

            }
        }
    }

    public void MouseClick()
    {
        b = !b;
    }

    public void DubbleClick()
    {
        print(Propinfo.slotName);
        switch(Propinfo.slotName)
        {
            case "口罩":
                role_Quality.health += 50;
                CheckDelete(Propinfo.slotItem.itemHold);
                break;

            case "微波食物":
                role_Quality.hungry += 40;
                CheckDelete(Propinfo.slotItem.itemHold);
                break;

            case "兔兔肉":

                break;


        }
          
    }
    public void CheckDelete(int num)
    {
        
        Propinfo.slotItem.itemHold -= 1;
        Propinfo.SetupSlot(Propinfo.slotItem);
        if (num == 0)
        {
            Destroy(gameObject);
        }
    }


}
