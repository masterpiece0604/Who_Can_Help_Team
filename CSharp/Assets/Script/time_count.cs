using UnityEngine;
using UnityEngine.UI;

public class time_count : MonoBehaviour
{
    /// <summary>
    /// 時間計時器
    /// </summary>
    public int timer_date=1;
    public Text timer_count;
    private float DateTime;
    static time_count tc;


    void Start()
    {
       timer_count.text ="01" ;
        //每8分鐘計算一天，先測試每分鐘計算一天
        DateTime = Time.time;
        tc = this;

    }
    private void Update()
    {
        if(Time.time- DateTime > 480f)
        {
            Time_Date();
        }
    }

    public static void Time_Date()
    {
        tc.timer_date++;
        tc.timer_count.text = tc.timer_date / 10 + "" + tc.timer_date % 10;
        tc.DateTime = Time.time;


    }
}
