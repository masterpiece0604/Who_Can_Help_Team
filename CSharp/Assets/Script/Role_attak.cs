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

    private void Start()
    {
        W_cooling = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        ArmsAttak = gameObject.GetComponent<Role_quality>().prop.GetComponent<Arms>().ArmAttack;
        if (Time.time-W_cooling > 3f)
        {
            W_atk();
            // 攻擊動畫可以加這裡
        }
        else
        {
            //print("冷卻中");
        }
    }

    private void W_atk()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
           
                // 按鍵按下去的時候就要執行攻擊或攻擊續力的動畫
                print("按下W鍵");
                KeyUpTime = Time.time; //儲存現在的時間
         

        }
        if(Input.GetKeyUp(KeyCode.W))
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
            
        }
    }

   
}
