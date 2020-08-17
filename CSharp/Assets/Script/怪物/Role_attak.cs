using System.Collections;
using UnityEngine;

public class Role_attak : MonoBehaviour
{

    private float KeyUpTime; //儲存按下W的時間
    private float W_cooling = 0f;
    [Header("按下W後的攻擊力")]
    public float WAttak = 5;

    [Header("武器攻擊力")]
    public float ArmsAttak = 5;

    [Header("主角")]
    public GameObject Role;

    public Animator ani;

    private void Start()
    {
        W_cooling = Time.time;
        ArmsAttak = gameObject.GetComponent<Role_quality>().prop.GetComponent<Arms>().ArmAttack;
        ani = this.gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time.time-W_cooling > 3f)
        {
            W_atk();
           
        }
      
    }

    private void W_atk()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
           
                // 按鍵按下去的時候就要執行攻擊或攻擊續力的動畫
                print("按下W鍵");
                KeyUpTime = Time.time; //儲存現在的時間
                ani.SetTrigger("Wattack");
                ani.SetBool("WSP3", false);
                ani.SetTrigger("WSP2");
                ani.SetBool("run", false);
                ani.SetBool("idle", false);
                ani.SetBool("attack", false);


        }
        if (Input.GetKey(KeyCode.W))
        {
            ani.SetBool("WSP2", true);


           
        } 
        if (Input.GetKeyUp(KeyCode.W))
            {
                KeyUpTime = Time.time - KeyUpTime; //判斷按了多久的W
                W_cooling = Time.time;
                if (KeyUpTime>2f)
                {
                    WAttak = ArmsAttak*2;
                    KeyUpTime = Time.time;
                }
                else if (KeyUpTime>1.5f)
                {
                    WAttak = ArmsAttak * 1.75f;
                    KeyUpTime = Time.time;
                }
                else if(KeyUpTime>1f)
                {
                    WAttak = ArmsAttak * 1.5f;
                    KeyUpTime = Time.time;
                }
                else if(KeyUpTime>0.5f)
                {
                    WAttak = ArmsAttak * 1.25f;
                    KeyUpTime = Time.time;
                }
                else
                {
                    WAttak = ArmsAttak;
                    KeyUpTime = Time.time;
                }
                ani.SetBool("WSP2", false);
                ani.SetBool("WSP3", true);
                
                ani.SetBool("idle", true);
            }
    }

   
}
