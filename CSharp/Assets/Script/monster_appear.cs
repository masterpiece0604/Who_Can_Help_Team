using UnityEngine;

public class monster_appear : MonoBehaviour
{
    public GameObject monster;
    [Header("此怪物最高數量")]
    public int Monster_most_total;
    private int Monster_total;

    

    void Start()
    {


        InvokeRepeating("start_monstercreator", 2, 2);

        

        // 重複執行(方案,第一次執行秒數,下次執行間隔秒數)
        Monster_total = 0;
     

    }
    public void start_monstercreator()
    {
        print("兩秒執行一次");
        monstercreator(Monster_total);
       Monster_total ++;
        if(Monster_total>4)
        {
            Monster_total = 5;
        }
    }
    public void Mons_num()
    {
        Monster_total = 2;
        print("Monster_total = 2");
    }



    public void monstercreator(int Monster_total)
    {
        
            
            //clonemonster = Instantiate(monster) as GameObject;
            int MonsterNum = 1;

        // 一次生成一個
        //print("執行第" + Monster_total + "次");
        if (Monster_total < Monster_most_total)
        {
            if (Monster_total < 3)
            {
                for (int i = 0; i < MonsterNum; i++)
                {
                    float x;
                    float z;

                    x = Random.Range(transform.position.x, transform.position.x + 5f);
                    // 隨機生成X座標，範圍空物件的+5f內

                    z = Random.Range(transform.position.z, transform.position.z + 5f);
                    // 隨機生成Z座標，範圍(30~35)

                    Instantiate(monster, new Vector3(x, 1.3f, z), Quaternion.identity);

                    Monster_total++;
                    //clonemonster = Instantiate(monster) as GameObject;

                }
            }


        }

    }
}