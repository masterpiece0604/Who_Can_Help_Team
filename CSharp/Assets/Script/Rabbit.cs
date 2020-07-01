using UnityEngine;

public class Rabbit : MonoBehaviour
{
    [Header("怪物遊走範圍")]
    public float wanderRadius; // 怪物有沒有跑出範圍

    [Header("兔兔逃跑範圍")]
    public float RunRadius;

    /// <summary>
    /// 怪物的狀態
    /// </summary>
    // 原地不動,隨機走動,面向玩家,追擊玩家,返回原點
    private enum MonsterState { STAND, WALK, RUN }

    private MonsterState currentState = MonsterState.STAND;
    // 預設怪物狀態為原地不走動

    public int[] action_weight = { 4, 6 }; //設定原地不動跟隨機走動的機率

    private float diatanceToPlay; //怪物跟玩家的距離
    private float diatanceToInt; //怪物跟初始位置的距離
    private Quaternion targetRotation; //怪物的方向
    private Vector3 initialPos; //怪物原始的位置
    private float lastActTime; //上一次執行指令的時間
    private float restTime = 5f; //兩個指令間的休息時間
    [Header("追擊範圍")]
    public float chaseDistance; //被追超過這個距離要返回

    [Header("怪物的移動速度")]
    public float walkspeed;
    private GameObject player;
    
    public Animal monster;//引用怪物身上的數據
    public GameObject role; // 引用角色身上的數據

    private Animator ani;




    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        initialPos = GetComponent<Transform>().position;
        role = GameObject.FindGameObjectWithTag("Player");
        ani = GetComponent<Animator>();
        RandomAct();


    }
    /// <summary>
    /// 走或靜止隨機動作
    /// </summary>
    void RandomAct()
    {
        //更新行動時間
        lastActTime = Time.time;

        // 設定一隨機數，讓怪物隨機移動
        float number = Random.Range(0, 10);
        print("隨機數"+ number);

        if (number <= action_weight[0])
        {
            currentState = MonsterState.STAND;

             print("怪物靜止中");

            // 如果有動作動畫可以放在這裡
        }
        else if (number > action_weight[0])
        {
            currentState = MonsterState.WALK;
            targetRotation = Quaternion.Euler(0, Random.Range(1, 5) * 90, 0);

             print("怪物走動中");
        }
    }
    private void Update()
    {
        switch (currentState)
        {
            case MonsterState.STAND:
                ani.SetBool("暫停", true);
                ani.SetBool("跑", false);
                if (Time.time - lastActTime > restTime)
                {
                    RandomAct();
                }
                MonstersDistanceCheck();
                break;

            case MonsterState.WALK:
                ani.SetBool("跑", true);
                ani.SetBool("暫停", false);
                transform.Translate(Vector3.forward * Time.deltaTime * walkspeed);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.1f);
                //print("轉向值:" + transform.rotation + "轉向值2:" + targetRotation);
                
                if (Time.time - lastActTime > restTime)
                {
                    RandomAct();
                }
                WanderRadiusCheck();
                break;

            case MonsterState.RUN:
                ani.SetBool("跑", true);
                ani.SetBool("暫停", false);
                transform.Translate(player.transform.forward * Time.deltaTime * walkspeed);
                targetRotation = Quaternion.LookRotation(transform.position -player.transform.position, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation,targetRotation, 0.1f);
                RunCheck();
                break;
            

        }
    }

    void RunCheck()
    {
        diatanceToPlay = Vector3.Distance(player.transform.position, transform.position);
        diatanceToInt = Vector3.Distance(transform.position, initialPos); //物件跟原始位置的距離

        if (diatanceToPlay> RunRadius)
        {
            RandomAct();
        }
        else if (diatanceToPlay < RunRadius)
        {
            currentState = MonsterState.RUN;
        }

        if(diatanceToInt > 20f)
        {
            Destroy(gameObject);

        }
    }
    /// <summary>
    /// 怪獸靜止狀態偵測 主角是否接近
    /// </summary>
    void MonstersDistanceCheck()
    {
        // 將此物件跟主角的距離存進diatanceToPlay
        diatanceToPlay = Vector3.Distance(player.transform.position, transform.position);
        if(diatanceToPlay< RunRadius)
        {
            currentState = MonsterState.RUN;
        }

    }

    /// <summary>
    ///遊走時判斷是否有超出範圍
    /// </summary>
    void WanderRadiusCheck()
    {
        diatanceToPlay = Vector3.Distance(player.transform.position, transform.position);
        diatanceToInt = Vector3.Distance(transform.position, initialPos); //物件跟原始位置的距離


        if (diatanceToInt > wanderRadius)
        {
            targetRotation = Quaternion.LookRotation(initialPos - transform.position, Vector3.up);
        }
        if (diatanceToPlay < RunRadius)
        {
            currentState = MonsterState.RUN;
        }
    }

    
    

   

}
   
