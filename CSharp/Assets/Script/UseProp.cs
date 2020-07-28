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
                role_Quality.hungry -= 40;
                CheckDelete(Propinfo.slotItem.itemHold);
                break;

            case "兔兔肉":
                role_Quality.sick += 20;
                CheckDelete(Propinfo.slotItem.itemHold);
                break;

            case "熟的兔兔肉":
                role_Quality.sick -= 20;
                CheckDelete(Propinfo.slotItem.itemHold);
                break;

            case "山豬肉":
                role_Quality.sick += 20;
                CheckDelete(Propinfo.slotItem.itemHold);
                break;

            case "熟的生豬肉":
                role_Quality.sick += 10;
                role_Quality.hungry -= 20;
                CheckDelete(Propinfo.slotItem.itemHold);
                break;

            case "獼猴肉":
                role_Quality.sick += 30;
                CheckDelete(Propinfo.slotItem.itemHold);
                break;

            case "生的獼猴肉":
                role_Quality.sick += 20;
                role_Quality.hungry -= 30;
                CheckDelete(Propinfo.slotItem.itemHold);
                break;

            case "蝙蝠肉":
                role_Quality.sick += 50;
                break;

            case "生的蝙蝠肉":
                role_Quality.sick += 50;
                break;

            case "香油錢收據":
                role_Quality.guilt -= 20;
                break;

            case "藥草A":
                role_Quality.sick -= 10;
                break;

            case "藥草B":
                role_Quality.sick -= 10;
                break;

            case "低級解毒藥":
                role_Quality.sick -= 15;
                break;

            case "中級解毒藥":
                role_Quality.sick -= 15;
                break;

            case "高級解毒藥":
                role_Quality.sick -= 15;
                break;
            case "研磨缽":
                Grinding();
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

    public void Grinding()
    {
        print("我在使用研磨缽");
    }

}
