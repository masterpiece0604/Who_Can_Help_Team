﻿using UnityEngine;
using UnityEngine.UI;

public class Role_static : MonoBehaviour
{
    public GameObject player;

    // 增加飢餓程度的時間
    private float HungryTime = 0;

    // 增加罪惡感的時間
    private float GuiltTime = 0;

    public Image GameOver;


    private void Start()
    {
        HungryTime = Time.time;
        GuiltTime = Time.time;
        GameOver.enabled = false;
        GameOver.GetComponentInChildren<Text>().text = "";
    }

    private void Update()
    {
        Hungry();
        Guilt();
        Sick();
    }

    public void Health()
    {
        if (player.GetComponent<Role_quality>().health - 5 >= 0)
        {
            player.GetComponent<Role_quality>().health -= 5;
            HungryTime = Time.time;

        }
        else
        {
            player.GetComponent<Role_quality>().health -= 5;
            player.GetComponent<Role_quality>().sick = -player.GetComponent<Role_quality>().health + player.GetComponent<Role_quality>().sick;
            player.GetComponent<Role_quality>().health = 0;
            HungryTime = Time.time;

        }
    }

    public void Sick()
    {
        if(player.GetComponent<Role_quality>().sick>=100)
        {
            GameOver.enabled = true;
            GameOver.GetComponentInChildren<Text>().text = "GameOver";
        }
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
            
            if (Time.time - HungryTime > 3f)
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "怪物攻擊")
        {
            Health();

        }
    }
}
