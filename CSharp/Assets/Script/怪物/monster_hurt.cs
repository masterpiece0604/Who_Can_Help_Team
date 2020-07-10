using System;
using UnityEngine;
using UnityEngine.UI;

public class monster_hurt : MonoBehaviour
{
    public GameObject Role;
    public enemy monster;
    public Image HP;
    public Ray ray;
    public Camera main_camera;
    private Animator animator;
    /// <summary>
    /// 判斷是否正在攻擊
    /// </summary>

    private float Last_Attack;

    private float ori_HP;
    #region 掉落物
    /// <summary>
    /// 機掰人掉落口罩
    /// </summary>
    public GameObject mask;

    /// <summary>
    /// 機掰人掉落金屬
    /// </summary>
    public GameObject metal;

    /// <summary>
    /// 機掰人掉落香油錢收據
    /// </summary>
    public GameObject fund;

    /// <summary>
    /// 機掰人掉落野味
    /// </summary>
    [Header("機掰人是否掉落野味"), Tooltip("這個欄位是用來確認機掰人是否掉落野味")]
    public GameObject meat;
    public string meat_type;
    #endregion


    private void Start()
    {
        Last_Attack = Time.time;
        Role = GameObject.FindGameObjectWithTag("Player");
        main_camera = Camera.FindObjectOfType<Camera>();
        animator = GetComponent<Animator>();
        ori_HP = monster.HP;

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
            HP.fillAmount = monster.HP / ori_HP;
            if (HP.fillAmount <= 0)
            {
                animator.SetBool("死亡", true);
                if (Role.GetComponent<Role_quality>().guilt < 100)
                {
                    Role.GetComponent<Role_quality>().guilt++;

                }
                Destroy(gameObject, 0.5f);

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
                HP.fillAmount = monster.HP / ori_HP;
                if (HP.fillAmount <= 0)
                {
                    animator.SetBool("死亡", true);
                    AddNewItem();
                    if (Role.GetComponent<Role_quality>().guilt < 100)
                    {
                        Role.GetComponent<Role_quality>().guilt++;

                    }
                    Destroy(gameObject, 0.5f);

                }


            }

        }


    }

    private void AddNewItem()
    {
        
    }
}
   
