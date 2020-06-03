using UnityEngine;
using UnityEngine.UI;

public class Arms : MonoBehaviour
{
    public Image MaskProp;

    [Header("是否擁有此武器")]
    public bool Arms_Have;

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

    private void Start()
    {
        Mask();
        
    }

    private void Update()
    {
        Mask();
    }

    public void Mask()
    {
        if(gameObject.GetComponent<Arms>().Arms_Have==false|| gameObject.GetComponent<Arms>().Durability<=0)
        {
            MaskProp.enabled = true;
        }
        else
        {
            MaskProp.enabled = false;
        }
    }


}
