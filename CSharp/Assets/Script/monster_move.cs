using UnityEditor;
using UnityEngine;

public class monster_move : MonoBehaviour
{
    [Header("怪物偵測的半徑")]
    public float defendRadius; //怪物偵測的半徑，如果角色走入這個半徑，怪物就要追擊
    [Header("怪物偵測到主角面向主角的距離")]
    public float alertRadius; // 角色走進這個半徑，怪物就看向主角
    [Header("怪物遊走範圍")]
    public float wanderRadius; // 怪物有沒有跑出範圍

    /// <summary>
    /// 怪物的狀態
    /// </summary>
    // 原地不動,隨機走動,面向玩家,追擊玩家,返回原點
    private enum MonsterState { STAND, WALK, WARN, CHASE, RETURN }

    private MonsterState currentState = MonsterState.STAND;
    // 預設怪物狀態為原地不走動

    public int[] action_weight = { 3, 7 }; //設定原地不動跟隨機走動的機率

    private float diatanceToPlay; //怪物跟玩家的距離
    private float diatanceToInt; //怪物跟初始位置的距離
    private Quaternion targetRotation; //怪物的方向
    private Vector3 initialPos; //怪物原始的位置
    private float lastActTime; //上一次執行指令的時間
    private float restTime = 5f; //兩個指令間的休息時間
    [Header("追擊範圍")]
    public float chaseDistance; //被追超過這個距離要放棄攻擊返回

    private bool is_warn = false;
    private bool is_run = false;

    [Header("怪物的攻擊距離")]
    public float attackRange;
    [Header("怪物的移動速度")]
    public float walkspeed;
    private GameObject player;

    public enemy monster;//引用怪物身上的數據
    public Role_quality role; // 引用角色身上的數據
    private float lastAtkTime; //上一次攻擊時間



    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        initialPos = gameObject.GetComponent<Transform>().position;

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

        if (number <= action_weight[0])
        {
            currentState = MonsterState.STAND;

           // print("怪物靜止中");

            // 如果有動作動畫可以放在這裡
        }
        else if (number > action_weight[0])
        {
            currentState = MonsterState.WALK;
            targetRotation = Quaternion.Euler(0, Random.Range(1, 5) * 90, 0);

           // print("怪物走動中");
        }
    }
    private void Update()
    {
        switch (currentState)
        {
            case MonsterState.STAND:
                if (Time.time - lastActTime > restTime)
                {
                    RandomAct();
                }
                MonstersDistanceCheck();
                break;

            case MonsterState.WALK:
                transform.Translate(Vector3.forward * Time.deltaTime * walkspeed);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.1f);
                //print("轉向值:" + transform.rotation + "轉向值2:" + targetRotation);


                if (Time.time - lastActTime > restTime)
                {
                    RandomAct();
                }
                WanderRadiusCheck();
                break;

            case MonsterState.WARN:
                if (!is_warn)
                {
                    // 如果有動畫可以加在這裡
                    is_warn = true;
                }

                // 怪會轉向玩家方向
               // print("怪獸看向主角哩~");
                targetRotation = Quaternion.LookRotation(player.transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.1f);
                WarnCheck();
                break;

            case MonsterState.CHASE:
               // print("追追追");
                if(!is_run)
                {
                    //跑步動畫放這兒
                    is_run = true;
                }
                transform.Translate(Vector3.forward*Time.deltaTime*walkspeed);
                // 轉向玩家
                targetRotation = Quaternion.LookRotation(player.transform.position - transform.position, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.1f);
                ChaseRadiusCheck();
                break;

            case MonsterState.RETURN:
                //print("我回去啦");
                targetRotation = Quaternion.LookRotation(initialPos - transform.position, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.1f);
                transform.Translate(Vector3.forward * Time.deltaTime * walkspeed);

                ReturnCheck();
                break;

        }
    }
    /// <summary>
    /// 怪獸靜止狀態偵測 主角是否接近
    /// </summary>
    void MonstersDistanceCheck()
    {
        // 將此物件跟主角的距離存進diatanceToPlay
        diatanceToPlay = Vector3.Distance(player.transform.position, transform.position);

        if (diatanceToPlay < attackRange)
        {
            //print("已進入怪物攻擊範圍");
            monster_attack();

        }
        else if (diatanceToPlay < defendRadius)
        {
            currentState = MonsterState.CHASE;
        }
        else if (diatanceToPlay < alertRadius)
        {
            currentState = MonsterState.WARN;
        }

    }

    /// <summary>
    ///遊走時判斷是否有超出範圍
    /// </summary>
    void WanderRadiusCheck()
    {
        diatanceToPlay = Vector3.Distance(player.transform.position, transform.position);
        diatanceToInt = Vector3.Distance(transform.position, initialPos); //物件跟原始位置的距離
        if (diatanceToPlay < attackRange)
        {
           // print("已進入怪物攻擊範圍");
            monster_attack();

        }
        else if (diatanceToPlay < defendRadius)
        {
            currentState = MonsterState.CHASE;
        }
        else if (diatanceToPlay < alertRadius)
        {
            currentState = MonsterState.WARN;
        }

        if (diatanceToInt > wanderRadius)  
        {
           // print("我跑太遠啦");
            targetRotation = Quaternion.LookRotation(initialPos - transform.position, Vector3.up);
        }
    }

    void WarnCheck()
    {
        diatanceToPlay = Vector3.Distance(player.transform.position, transform.position);
        if (diatanceToPlay < defendRadius)
        {
            is_warn = false;
            currentState = MonsterState.CHASE; //在靠近就要開始追主角了!!
        }
        else if (diatanceToPlay > alertRadius)
        {
            is_warn = false;
            RandomAct(); // 主角遠離怪物繼續癡呆運動
        }
    }

    void ChaseRadiusCheck()
    {
        diatanceToPlay = Vector3.Distance(player.transform.position, transform.position);
        diatanceToInt = Vector3.Distance(transform.position, initialPos); //物件跟原始位置的距離
        if (diatanceToPlay < attackRange)
        {
            //print("已進入怪物攻擊範圍");
            monster_attack();

        }
        // 超過距離怪物要回去
        if (diatanceToInt > wanderRadius) //如果想讓怪物一直追著主角跑調整這裡(diatanceToPlay>chaseDistance)
        {
            currentState = MonsterState.RETURN;
        }

    }

    void ReturnCheck()
    {
        diatanceToInt = Vector3.Distance(transform.position, initialPos);

        if (diatanceToInt<0.5f)
        {
            is_run = false;
            RandomAct();
        }
    }
    void monster_attack()
    {

        // 怪物攻擊動畫擺這裡
       
        // 設定兩秒攻擊一次

        if (Time.time - lastAtkTime > monster.attack_frequency)
        {
            role.health -= monster.hurt;
            lastAtkTime = Time.time;
        }
      



    }
}

