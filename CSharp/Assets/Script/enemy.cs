using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    /// <summary>
    /// 機掰人的血量
    /// </summary>
    [Header("機掰人的血量"), Tooltip("這個欄位是用來機掰人的血量")]
    public int HP;

    /// <summary>
    /// 機掰人的傷害值
    /// </summary>
    [Header("機掰人的傷害值"), Tooltip("這個欄位是用來機掰人的傷害")]
    public int hurt;

    /// <summary>
    /// 機掰人的攻擊範圍
    /// </summary>
    [Header("機掰人的攻擊範圍"), Tooltip("這個欄位是用來機掰人的攻擊範圍")]
    public int attack_range;

    /// <summary>
    /// 機掰人的類型
    /// </summary>
    [Header("機掰人的類型"), Tooltip("這個欄位是用來機掰人的攻擊類型")]
    public string attack_type;

    /// <summary>
    /// 機掰人的技能
    /// </summary>
    [Header("機掰人的技能"), Tooltip("這個欄位是用來確認機掰人是否有技能")]
    public bool skill;

    /// <summary>
    /// 機掰人是否掉落口罩
    /// </summary>
    [Header("機掰人是否掉落口罩"), Tooltip("這個欄位是用來確認機掰人是否掉落口罩")]
    public bool mask;

    /// <summary>
    /// 機掰人是否掉落金屬
    /// </summary>
    [Header("機掰人是否掉落金屬"), Tooltip("這個欄位是用來確認機掰人是否掉落金屬")]
    public bool metal;

    /// <summary>
    /// 機掰人是否掉落香油錢收據
    /// </summary>
    [Header("機掰人是否掉落香油錢收據"), Tooltip("這個欄位是用來確認機掰人是否掉落香油錢收據")]
    public bool fund;

    /// <summary>
    /// 機掰人是否掉落野味
    /// </summary>
    [Header("機掰人是否掉落野味"), Tooltip("這個欄位是用來確認機掰人是否掉落野味")]
    public bool meat;
    public string meat_type;



    /// <summary>
    /// 初始掉落機率設定
    /// </summary>

    void Awake()
    {
        int mask_Probability = UnityEngine.Random.Range(1, 10); //口罩的隨機參數
        
        if (mask_Probability ==1)
            {
                mask = true;
            }
        else 
            {
                mask = false;
            }

        int metal_Probability = UnityEngine.Random.Range(1, 5); //金屬的機率參數
       
        if (metal_Probability == 1)
        {
            metal = true;
        }
        else {
            metal = false;
        }

        int fund_Probability = UnityEngine.Random.Range(1, 10); //香油錢收據掉落機率
        if (fund_Probability > 3)
        {
            fund = true;
        }
        else
        {
            fund = false;
        }

        int meat_Probability = UnityEngine.Random.Range(1, 5); //野味掉落機率
        if (meat_Probability == 1)
        {
            meat = true;

            int meat_type_Probability = UnityEngine.Random.Range(1, 100); // 1~32 33~64 65~96 97~100
            if (meat_type_Probability>96)
            {
                meat_type = "蝙蝠肉";
            }
            else if(meat_type_Probability>64 && meat_type_Probability < 97)
            {
                meat_type = "獼猴肉";
            }
            else if (meat_type_Probability > 32 && meat_type_Probability < 65)
            {
                meat_type = "山豬肉";
            }
            else if (meat_type_Probability <33)
            {
                meat_type = "兔兔肉";
            }
        }
        else
        {
            meat = false;
        }

    }
    

           


  

}

