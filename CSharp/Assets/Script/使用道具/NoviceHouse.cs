using UnityEngine;
using UnityEngine.UI;

public class NoviceHouse : MonoBehaviour
{
    public time_count date;
    [Header("新手小木屋對話")]
    public GameObject Natice_House;
    public Item Naticehouse;

    public void PassNight()
    {
        if(Naticehouse.itemHold>0)
        {
            date.Time_Date();
            Naticehouse.itemHold--;
        }
    }


    public void Close()
    {
        Destroy(Natice_House);
    }
}
