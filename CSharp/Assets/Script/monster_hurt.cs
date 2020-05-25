using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class monster_hurt : MonoBehaviour
{
    public Role_attak Role;
    public enemy monster;
    public Image HP;
    public Ray ray;
    public Camera main_camera;
    private float Last_Attack;

    private void Start()
    {
        Last_Attack = Time.time;
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.W) && Vector3.Distance(Role.transform.position,transform.position)<1f)
        {
            MonsterHurt();
        }
        else if (!Input.GetKey(KeyCode.W)&&Input.GetMouseButtonDown(1)  && Vector3.Distance(Role.transform.position, transform.position) < 1f)
        {
            Mouse_atk();
        }

    }
    public void MonsterHurt()
    {
        if ((Time.time - Last_Attack) > 1f)
        {
            // 攻擊動畫可以加這裡
            Last_Attack = Time.time;
            monster.HP -= Role.WAttak;
            HP.fillAmount = ((int)monster.HP - Role.WAttak) / 100;
            if (HP.fillAmount <= 0)
            {
                gameObject.SetActive(false);
            }
        }
       


    }
    private void Mouse_atk()
    {
       
            ray = main_camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit[] raycasthit = Physics.RaycastAll(ray, 50);

            for (int i = 0; i < raycasthit.Length; i++)
            {
                if (raycasthit[i].collider.tag == "怪獸")
                {
                    if (Vector3.Distance(Role.transform.position, transform.position) < 1f)
                    {
                        MonsterHurt();
                        print("滑鼠攻擊");
                    }
                }

            }

        
    }
}
