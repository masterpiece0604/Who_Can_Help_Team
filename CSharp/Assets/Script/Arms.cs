using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arms : MonoBehaviour
{
    [Header("是否可以砍樹")]
    public bool Cut_Tree;

    [Header("是否可以挖礦")]
    public bool Mining;

    [Header("是否是近戰")]
    public bool Melee;       

    [Header("耐久度")]
    public float Durability;

    [Header("攻擊力")]
    public float ArmAttack;

    [Header("範圍")]
    public float ArmRange;

    [Header("攻速")]
    public float ArmSpeed;



}
