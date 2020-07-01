using UnityEngine;
using UnityEngine.UI;

public class time_count : MonoBehaviour
{
    /// <summary>
    /// 時間計時器
    /// </summary>
   private int timer_date=1;
    public Text timer_count;


    void Start()
    {
        //每8分鐘計算一天，先測試每分鐘計算一天
        InvokeRepeating("Time_Date", 60f, 60f);
    }

    void Time_Date()
    {
        timer_date++;
        print("第" + timer_date + "天");
        timer_count.text = "第" + timer_date + "天";
    }
}
