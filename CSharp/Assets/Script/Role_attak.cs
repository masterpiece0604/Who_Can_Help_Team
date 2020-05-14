using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Role_attak : MonoBehaviour
{
    private float KeyUpTime; //儲存按下W的時間

    // Update is called once per frame
    void Update()
    {
        W_atk();
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
            print("按了這麼久:"+(int)KeyUpTime);
        }
    }
}
