using UnityEngine;

public class Introduce : MonoBehaviour
{
    public GameObject days,littleMap,weapon,state,info,item,itemClose;
    [Header("開局UI簡介")]
    public GameObject BeginUIIntroduce;
    public ctrllor1 ctrllor1;

    private void Start()
    {
        days.SetActive(true);
        littleMap.SetActive(false);
        weapon.SetActive(false);
        state.SetActive(false);
        info.SetActive(false);
        item.SetActive(false);

        itemClose.SetActive(false);
        
        BeginUIIntroduce.SetActive(true);
        
    }

    private void Update()
    {
        if (BeginUIIntroduce.activeSelf == true)
        {
            ctrllor1.Introduce = true;
        }
        if (item.activeSelf == true && Input.GetKeyDown(KeyCode.I))
        {
            //ctrllor1.Introduce = false;
            itemClose.SetActive(true);
            item.SetActive(false);
            
        }
        else if (itemClose.activeSelf == true && Input.GetKeyDown(KeyCode.I))
        {
            ctrllor1.Introduce = false;
            BeginUIIntroduce.SetActive(false);
            
        }
    }
    
    public void daysToInfo()
    {
        days.SetActive(false);
        info.SetActive(true);
    }

    public void InfoToWeapon()
    {
        info.SetActive(false);
        weapon.SetActive(true);
    }

    public void weaponToState()
    {
        weapon.SetActive(false);
        state.SetActive(true);
    }

    public void StateToLittleMap()
    {
        state.SetActive(false);
        littleMap.SetActive(true);
    }

    public void LittleMapToItem()
    {
        littleMap.SetActive(false);
        item.SetActive(true);
    }
}
