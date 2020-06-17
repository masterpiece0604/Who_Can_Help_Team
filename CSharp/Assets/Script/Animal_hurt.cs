using UnityEngine;
using UnityEngine.UI;

public class Animal_hurt : MonoBehaviour
{
    public GameObject Role;
    public Animal ani;
    public Image HP;
    public Ray ray;
    public Camera main_camera;
    private Animator animator;

    /// <summary>
    /// 判斷是否正在攻擊
    /// </summary>
    private bool Is_Atk;


   
    private float Last_Attack;

    private void Start()
    {
        Last_Attack = Time.time;
        Role = GameObject.FindGameObjectWithTag("Player");
        main_camera = Camera.FindObjectOfType<Camera>();
        animator = GetComponent<Animator>();

    }


    private void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.W) && Vector3.Distance(Role.transform.position, transform.position) < 1f)
        {
            MonsterHurt();
            Is_Atk = false;
        }
        if (Input.GetMouseButtonDown(1) && (Vector3.Distance(Role.transform.position, transform.position) < 1f))
        {
            print("執行滑鼠攻擊");
            Mouse_atk();
            Is_Atk = false;
        }

    }
    public void MonsterHurt()
    {
        if ((Time.time - Last_Attack) > 1f)
        {

            Is_Atk = true;

            Last_Attack = Time.time;
            ani.HP -= Role.GetComponent<Role_attak>().WAttak;
            HP.fillAmount = ((int)ani.HP - Role.GetComponent<Role_attak>().WAttak) / 100;
            if (HP.fillAmount <= 0)
            {
                
                animator.SetBool("死亡", true);
                
                Destroy(gameObject,1.5f);

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
                ani.HP -= Role.GetComponent<Role_attak>().ArmsAttak;
                HP.fillAmount = ((int)ani.HP - Role.GetComponent<Role_attak>().ArmsAttak) / 100;
                if (HP.fillAmount <= 0)
                {
                    animator.SetBool("暫停", false);
                    animator.SetBool("跑", false);
                    animator.SetBool("死亡", true);
                    Destroy(gameObject);

                }
                print("滑鼠攻擊");

            }

        }


    }
}
