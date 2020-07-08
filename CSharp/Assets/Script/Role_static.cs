using UnityEngine;

public class Role_static : MonoBehaviour
{
    public GameObject player;

    // 增加飢餓程度的時間
    private float HungryTime = 0;

    // 增加罪惡感的時間
    private float GuiltTime = 0;


    private void Start()
    {
        HungryTime = Time.time;
        GuiltTime = Time.time;
    }

    private void Update()
    {
        Hungry();
        Guilt();
    }

    public void Health()
    {

    }

    public void Sick()
    {

    }

    /// <summary>
    /// 飢餓度
    /// </summary>
    public void Hungry()
    {
        if(player.GetComponent<Role_quality>().hungry<100)
        {
            if(Time.time - HungryTime > 6)
                    {
                        player.GetComponent<Role_quality>().hungry += 1;
                        HungryTime = Time.time;
                       
                    }
        }
        else
        {
            
            if (Time.time - HungryTime > 60)
            {
                if (player.GetComponent<Role_quality>().health-5 >=0)
                {
                    player.GetComponent<Role_quality>().health -= 5;
                    HungryTime = Time.time;
                    
                }
                else
                {
                    player.GetComponent<Role_quality>().health -= 5;
                    player.GetComponent<Role_quality>().sick = -player.GetComponent<Role_quality>().health + player.GetComponent<Role_quality>().sick;
                    player.GetComponent<Role_quality>().health =0;
                    HungryTime = Time.time;
                   
                }
           }
        }
        
    }

    public void Guilt()
    {
        if (player.GetComponent<Role_quality>().guilt >= 100)
        {
            if(Time.time - GuiltTime>3f)
            {
                 if (player.GetComponent<Role_quality>().health - 5 >= 0)
                 {
                      player.GetComponent<Role_quality>().health -= 5;
                      GuiltTime = Time.time;

                 }
                  else
                   {
                       player.GetComponent<Role_quality>().health -= 5;
                       player.GetComponent<Role_quality>().sick = -player.GetComponent<Role_quality>().health + player.GetComponent<Role_quality>().sick;
                       player.GetComponent<Role_quality>().health = 0;
                       GuiltTime = Time.time;

                   }
            }
           
        }
    }
}
