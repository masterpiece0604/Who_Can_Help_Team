using UnityEngine;
using UnityEngine.UI;

public class monster_hurt : MonoBehaviour
{
    public GameObject Role;
    public enemy monster;
    public Image HP;
    public Ray ray;
    public Camera main_camera;
    /// <summary>
    /// 判斷是否正在攻擊
    /// </summary>
    
    private float Last_Attack;

    private void Start()
    {
        Last_Attack = Time.time;
        Role = GameObject.FindGameObjectWithTag("Player");
        main_camera = Camera.FindObjectOfType<Camera>();
        
    }
    

    private void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.W) && Vector3.Distance(Role.transform.position, transform.position) < 1f)
        {
            MonsterHurt();
                   }
        if (Input.GetMouseButtonDown(1) && (Vector3.Distance(Role.transform.position, transform.position) < 1f))
        {
            print("執行滑鼠攻擊");
            Mouse_atk();
        }

    }
    public void MonsterHurt()
    {
        if ((Time.time - Last_Attack) > 1f)
        {

            Last_Attack = Time.time;
            monster.HP -= Role.GetComponent<Role_attak>().WAttak;
            HP.fillAmount = ((int)monster.HP - Role.GetComponent<Role_attak>().WAttak) / 100;
            if (HP.fillAmount <= 0)
            {
                
                if (Role.GetComponent<Role_quality>().guilt < 100)
                {
                    Role.GetComponent<Role_quality>().guilt ++;
                   
                }
                Destroy(gameObject,0.5f);

            }
        }



    }
    private void Mouse_atk()
    {

        ray = main_camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit[] raycasthit = Physics.RaycastAll(ray, 50);

        for (int i = 0; i < raycasthit.Length; i++)
        {
            if (raycasthit[i].collider.tag == gameObject.tag)
            {
                monster.HP -= Role.GetComponent<Role_attak>().ArmsAttak;
                HP.fillAmount = ((int)monster.HP - Role.GetComponent<Role_attak>().ArmsAttak) / 100;
                if (HP.fillAmount <= 0)
                {

                    if (Role.GetComponent<Role_quality>().guilt < 100)
                    {
                        Role.GetComponent<Role_quality>().guilt++;

                    }
                    Destroy(gameObject,0.5f);

                }
               

            }

        }


    }

    
}
