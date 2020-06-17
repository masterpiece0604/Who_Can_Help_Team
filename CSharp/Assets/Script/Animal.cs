using UnityEngine;

public class Animal : MonoBehaviour
{
    /// <summary>
    /// 動物的血量
    /// </summary>
    [Header("動物的血量"), Tooltip("這個欄位是動物血量")]
    public float HP;

    /// <summary>
    /// 動物的傷害值
    /// </summary>
    [Header("動物的傷害值"), Tooltip("這個欄位是動物的傷害")]
    public float hurt;

    /// <summary>
    /// 機掰人的攻擊範圍
    /// </summary>
    [Header("動物的攻擊範圍"), Tooltip("這個欄位是用來動物的攻擊範圍")]
    public float attack_range;

    [Header("動物的攻擊頻率"), Tooltip("每幾秒攻擊一次")]
    public float attack_frequency;

    [Header("掉落物品")]
    public string Falling;
}
