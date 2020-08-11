using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{

    public static PlayData data;
    public static bool load;
    public Inventory bag;
        
    public void OldGame()
    {
        load = true;
    }

    public void SaveGame()
    {
        WriteData();
    }


    public void ReadData()
    {
       
    }
    public void WriteData()
    {
        Transform target = GameObject.FindGameObjectWithTag("Player").transform;
        Role_quality player = GameObject.FindGameObjectWithTag("Player").GetComponent<Role_quality>();
       

        data.pos = target.position;
        data.health = player.health;
        data.hungry = player.hungry;
        data.guilt = player.guilt;
        data.sick = player.sick;
        data.bag = bag;

        string json = JsonUtility.ToJson(data);

        PlayerPrefs.SetString("儲存資料1",json);

    }

}
