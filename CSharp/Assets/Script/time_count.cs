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


    void Start()
    {
        timer_count.text ="01" ;
        //每8分鐘計算一天，先測試每分鐘計算一天
        DateTime = Time.time;

    }
    private void Update()
    {
        if(Time.time- DateTime > 480f)
        {
            Time_Date();
        }
    }

    public void Time_Date()
    {
        timer_date++;
        timer_count.text = timer_date / 10 + "" + timer_date % 10;
        DateTime = Time.time;


    }
}
