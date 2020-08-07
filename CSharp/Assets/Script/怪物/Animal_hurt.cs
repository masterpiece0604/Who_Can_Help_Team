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

    
   
    private float Last_Attack;

    public Item thisItem;
    public Inventory playerInventory;

    private float ori_HP; //儲存原始血量

    private void Start()
    {
        Last_Attack = Time.time;
        Role = GameObject.FindGameObjectWithTag("Player");
        GameObject gameObject = GameObject.FindGameObjectWithTag("MainCamera");
        main_camera = gameObject.GetComponent<Camera>();
        
        animator = GetComponent<Animator>();
        ori_HP = ani.HP;
       

    }


    private void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.W) && Vector3.Distance(Role.transform.position, transform.position) < 3f)
        {
            MonsterHurt();
           
        }
        if (Input.GetMouseButtonDown(1) && (Vector3.Distance(Role.transform.position, transform.position) < 3f))
        {
             Mouse_atk();
        }

    }
    public void MonsterHurt()
    {
        if ((Time.time - Last_Attack) > 1f)
        {

           
            Last_Attack = Time.time;
            ani.HP -= Role.GetComponent<Role_attak>().WAttak;

            HP.fillAmount = ani.HP  / ori_HP;
            if (HP.fillAmount <= 0)
            {
                animator.SetBool("死亡", true);
                AddNewItem();
                if (Role.GetComponent<Role_quality>().guilt<100)
                {
                    
                    Role.GetComponent<Role_quality>().guilt ++;
                }
                
                Destroy(gameObject,0.8f);

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
                    ani.HP -= Role.GetComponent<Role_attak>().ArmsAttak;
                    HP.fillAmount = ani.HP  / ori_HP;
                  
                    if (HP.fillAmount <= 0)
                    {
                        animator.SetBool("死亡", true);
                        AddNewItem();
                        if (Role.GetComponent<Role_quality>().guilt < 100)
                        {
                            Role.GetComponent<Role_quality>().guilt++;
                        }
                        
                        Destroy(gameObject, 0.8f);

                    }
                   

                }

            }

        }
    }

    public void AddNewItem()
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
