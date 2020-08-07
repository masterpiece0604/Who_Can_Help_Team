using System;
using UnityEngine;
using UnityEngine.UI;

public class monster_hurt : MonoBehaviour
{
    public GameObject Role_object;
    public Role_attak Role;
    public Role_quality RoleQ;
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
    public Item mask;

    /// <summary>
    /// 機掰人掉落金屬
    /// </summary>
    public Item metal;

    /// <summary>
    /// 機掰人掉落香油錢收據
    /// </summary>
    public Item fund;
   

    /// <summary>
    /// 機掰人掉落野味
    /// </summary>
    [Header("機掰人是否掉落野味"), Tooltip("這個欄位是用來確認機掰人是否掉落野味")]
    public string meat_type;
    public Inventory playerInventory;

    public Item bat;
    public Item rabbit;
    public Item pig;
    public Item monkey;
    #endregion


    private void Start()
    {
        Last_Attack = Time.time;
        Role_object = GameObject.FindGameObjectWithTag("Player");
        Role = Role_object.GetComponent<Role_attak>();
        RoleQ = Role_object.GetComponent<Role_quality>();
        GameObject gameObject = GameObject.FindGameObjectWithTag("MainCamera");
        main_camera = gameObject.GetComponent<Camera>();
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
            Mouse_atk();
        }

    }
    public void MonsterHurt()
    {
        if ((Time.time - Last_Attack) > 1f)
        {

            Last_Attack = Time.time;
            monster.HP -= Role.WAttak;
            HP.fillAmount = monster.HP / ori_HP;
            if (HP.fillAmount <= 0)
            {
                animator.SetBool("死亡", true);
                if (RoleQ.guilt < 100)
                {
                    RoleQ.guilt++;

                }
                Destroy(gameObject, 0.5f);

            }
        }



    }
    private void Mouse_atk()
    {
        if ((Time.time - Last_Attack) > 1f)
        {
            Last_Attack = Time.time;
            ray = main_camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit[] raycasthit = Physics.RaycastAll(ray, 50);

            for (int i = 0; i < raycasthit.Length; i++)
            {
                if (raycasthit[i].collider.tag == gameObject.tag)
                {
                    monster.HP -= Role.ArmsAttak;
                    HP.fillAmount = monster.HP / ori_HP;
                    if (HP.fillAmount <= 0)
                    {
                        animator.SetBool("死亡", true);
                        GetProp();
                        if (RoleQ.guilt < 100)
                        {
                            RoleQ.guilt++;

                        }
                        Destroy(gameObject, 0.5f);

                    }


                }

            }
        }

    }

    private void GetProp()
    {
        if(monster.mask)
        {
            AddNewItem(mask);
        }
        if(monster.metal)
        {
            AddNewItem(metal);
        }
        if(monster.fund)
        {
            AddNewItem(fund);
        }
        if (monster.meat)
        {
            if (monster.bat)
            {
                AddNewItem(bat);
            }
            if(monster.rabbit)
            {
                AddNewItem(rabbit);
            }
            if (monster.pig)
            {
                AddNewItem(pig);
            }
            if (monster.monkey)
            {
                AddNewItem(monkey);
            }
        }
    }

    private void AddNewItem(Item thisItem)
    {

        if (!playerInventory.itemList.Contains(thisItem))
        {
            thisItem.itemHold += 1;
            playerInventory.itemList.Add(thisItem);
            for (int i = 0; i < playerInventory.itemList.Count; i++)
            {
                if (playerInventory.itemList[i] == null)
                {
                    playerInventory.itemList[i] = thisItem;
                    break;
                }
            }
        }
        else
         {
            thisItem.itemHold += 1;
        }

        InventoryManager.RefreshItem();
    }
}
   
