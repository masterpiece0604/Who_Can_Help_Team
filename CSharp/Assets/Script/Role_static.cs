using UnityEngine;
using UnityEngine.UI;

public class Role_static : MonoBehaviour
{
    public Role_quality player;

    // 增加飢餓程度的時間
    private float HungryTime = 0;

    // 增加罪惡感的時間
    private float GuiltTime = 0;

    public Image GameOver;

    public Animal Bat;
    public Animal Monkey;
    public enemy G8Person;



    private void Start()
    {
        HungryTime = Time.time;
        GuiltTime = Time.time;
        GameOver.enabled = false;
        GameOver.GetComponentInChildren<Text>().text = "";
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Role_quality>();
    }
    private void FixedUpdate()
    {
        Hungry();
        Guilt();
        Sick();
    }
    
    public void Health_Light()
    {
        if (player.health - Bat.hurt >= 0)
        {
            player.health -= Bat.hurt;
            GuiltTime = Time.time;

        }
        else
        {
            player.health -= Bat.hurt;
            player.sick = -player.health + player.sick;
            player.health = 0;
            GuiltTime = Time.time;

        }
    }

    public void Health_Teeth()
    {
        if (player.health - G8Person.hurt >= 0)
        {
            player.health -= G8Person.hurt;
            GuiltTime = Time.time;

        }
        else
        {
            player.health -= G8Person.hurt;
            player.sick = -player.health + player.sick;
            player.health = 0;
            GuiltTime = Time.time;

        }
    }
    public void Health_Banana()
    {
        if (player.health - Monkey.hurt >= 0)
        {
            player.health -= Monkey.hurt;
            GuiltTime = Time.time;

        }
        else
        {
            player.health -= Monkey.hurt;
            player.sick = -player.health + player.sick;
            player.health = 0;
            GuiltTime = Time.time;

        }
    }

    public void Sick()
    {
        if(player.sick>=100)
        {
            GameOver.enabled = true;
            GameOver.GetComponentInChildren<Text>().text = "GameOver";
        }
        if (player.sick < 0)
        {
            player.sick = 0;
        }
    }

    /// <summary>
    /// 飢餓度
    /// </summary>
    public void Hungry()
    {
        if(player.hungry<100)
        {
            if(Time.time - HungryTime > 6)
                    {
                        player.hungry += 1;
                        HungryTime = Time.time;
                       
                    }
        }
        else
        {
            
            if (Time.time - HungryTime > 60f)
            {
                if (player.health-5 >=0)
                {
                    player.health -= 5;
                    HungryTime = Time.time;
                    
                }
                else
                {
                    player.health -= 5;
                    player.sick = -player.health + player.sick;
                    player.health =0;
                    HungryTime = Time.time;
                   
                }
           }
        }
        if (player.hungry < 0)
        {
            player.hungry = 0;
        }

    }

    public void Guilt()
    {
        if (player.guilt >= 100)
        {
            if(Time.time - GuiltTime>60f)
            {
                 if (player.health - 5 >= 0)
                 {
                      player.health -= 5;
                      GuiltTime = Time.time;

                 }
                  else
                   {
                       player.health -= 5;
                       player.guilt = -player.health + player.guilt;
                       player.health = 0;
                       GuiltTime = Time.time;

                   }
            }
           
        }
        if(player.guilt<0)
        {
            player.guilt = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "光束")
        {
            Health_Light();           

        }else if(other.tag == "假牙")
        {
            Health_Teeth();
        }
        else if(other.tag == "香蕉")
        {
            Health_Banana();
        }
    }
}
