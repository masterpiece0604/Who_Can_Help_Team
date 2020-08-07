using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BagAssign : MonoBehaviour
{
    static BagAssign BA;
    public Inventory myBag;
    public Inventory Eqi;
    public Inventory Use;
    public Inventory Make;


    public List<Item> prop;
    public List<Item> Eqi_Prop;
    public List<Item> Use_Prop;
    public List<Item> Make_Prop;

    static InventoryManager instance;
    internal static object re;

    private void Start()
    {
        reassign();
    }

    public void reassign()
    {
        prop = myBag.itemList;
        Assgin_Eqi();
        Assgin_Use();
        Assgin_Make();
    }


    private void Assgin_Eqi()
    {
        
            IEnumerable<Item> Get_Prop =
            from A in prop
            where A.equipment == true
            select A;

        Eqi_Prop.Clear();
        foreach (Item A in Get_Prop)
        {
            Eqi_Prop.Add(A);
        }
        Eqi.itemList = Eqi_Prop;

    }
    private void Assgin_Use()
    {
        IEnumerable<Item> Get_Prop =
            from A in prop
            where A.use == true
            select A;
        Use_Prop.Clear();
        foreach (Item A in Get_Prop)
        {
            Use_Prop.Add(A);
        }
        Use.itemList = Use_Prop;
    }
    private void Assgin_Make()
    {

        IEnumerable<Item> Get_Prop =
            from A in prop
            where A.manufactur == true
            select A;
        Make_Prop.Clear();
        foreach (Item A in Get_Prop)
        {
            Make_Prop.Add(A);
        }
        Make.itemList = Make_Prop;
    }

    
     
}