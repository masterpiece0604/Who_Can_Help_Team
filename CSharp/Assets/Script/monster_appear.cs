using UnityEngine;

public class monster_appear : MonoBehaviour
{
    public GameObject monster;
    GameObject clonemonster;
    [Header("此怪物最高數量")]
    public int Monster_most_total;
    private int Monster_total;


    void Start()
    {
        InvokeRepeating("monstercreator", 5, 2);
        // 重複執行(方案,第一次執行秒數,下次執行間隔秒數)
        Monster_total = 0;

    }

    public void monstercreator()
    {
        //clonemonster = Instantiate(monster) as GameObject;
        int MonsterNum = 1;
        // 一次生成一個
        //print("執行第" + Monster_total + "次");
        if (Monster_total < 3)
        {
            for (int i = 0; i < MonsterNum; i++)
            {
                float x;
                float z;

                x = Random.Range(30, 35);
                // 隨機生成X座標，範圍(30~35)

                z = Random.Range(30, 35);
                // 隨機生成Z座標，範圍(30~35)

                Instantiate(monster, new Vector3(x, 1.3f, z), Quaternion.identity);
                Monster_total++;
                //clonemonster = Instantiate(monster) as GameObject;
                if (Monster_total >= Monster_most_total)
                {
                    CancelInvoke();
                }
            }
        }



    }
}