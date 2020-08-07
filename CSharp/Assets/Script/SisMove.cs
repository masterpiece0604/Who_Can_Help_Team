using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SisMove : MonoBehaviour
{
    private enum SisState { idle,move };
    public int[] action_weight = { 3, 7 };
    private SisState currentState = SisState.idle;
    private float lastActTime;
    private Animator ani;

    private void Start()
    {
        ani = GetComponent<Animator>();
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
            currentState = SisState.idle;
        }
        else if (number > action_weight[0])
        {
            currentState = SisState.move;
        }
    }

    private void FixedUpdate()
    {
        switch (currentState)
        {
            case SisState.idle:
                ani.SetBool("idle",true);
                break;
            case SisState.move:
                ani.SetBool("look", true);
                break;
        }
        
    }

}
