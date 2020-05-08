using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_move : MonoBehaviour
{
    [Header("怪物偵測的半徑")]
    public float alertRadius; //怪物偵測的半徑，如果角色走入這個半徑，怪物就要追擊
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
    private float wanderRadius; // 怪物有沒有跑出範圍
    private Quaternion targetRotation; //怪物的方向
    private Vector3 initialPos; //怪物原始的位置
    private float lastActTime; //上一次執行指令的時間
    private float restTime = 5f; //兩個指令間的休息時間

    private bool is_warn = false;
    private bool is_run = false;

    [Header("怪物的攻擊距離")]
    public float attackRange;
    [Header("怪物的移動速度")]
    public float walkspeed;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("怪獸");
        initialPos = gameObject.GetComponent<Transform>().position;

        RandomAct();


    }

    void RandomAct()
    {
        //更新行動時間
        lastActTime = Time.time;

        // 設定一隨機數，讓怪物隨機移動
        float number = Random.Range(0, 10);

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
                if (Time.time - lastActTime > restTime)
                {
                    RandomAct();
                }
                break;

            case MonsterState.WALK:
                transform.Translate(Vector3.forward * Time.deltaTime * walkspeed);
                transform.localRotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.1f);
                print("轉向值:" + transform.rotation + "轉向值2:" + targetRotation);


                if (Time.time - lastActTime > restTime)
                {
                    RandomAct();
                }
                break;
        }
    }


}
