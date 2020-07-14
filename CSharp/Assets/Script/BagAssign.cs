using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BagAssign : MonoBehaviour
{
    public Inventory myBag;

    public List<Item> prop;
    public List<Item> Arms_Prop;


    private void Start()
    {
        prop = myBag.itemList;
        Delete_null();
        Assgin();
        print(prop[0].name);
    }
    private void Delete_null() 
    { 

    }

    private void Assgin()
    {
        IEnumerable<Item> Arms =
            from A in prop
            where A.equipment == true
            select A;
       foreach(Item A in Arms)
        {
            print(A.name);
        }
       
    }
}
