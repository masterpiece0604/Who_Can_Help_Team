using UnityEngine;
using UnityEngine.UI;

public class time_count : MonoBehaviour
{
    /// <summary>
    /// 時間計時器
    /// </summary>
    public static int timer_date=1;
    public Text timer_count;
    private float DateTime;
    private float LightTime;
    private float minTime;
    static time_count tc;

    public Light Sunlight;


    void Start()
    {
       timer_count.text ="01" ;
        LightTime = Time.time;
        DateTime = Time.time;
        tc = this;

    }
  
    private void FixedUpdate()
    {
        if (Time.time - LightTime > 0.2f)
        {
            
            if(Sunlight.transform.eulerAngles.x >180)
            {
                Sunlight.transform.rotation = Quaternion.identity;
                Sunlight.transform.Rotate(Vector3.right * 0.0666f);
            }
            else if (Sunlight.transform.rotation.x < 20)
            {
                Sunlight.transform.Rotate(Vector3.right*0.0666f);
            }
            else
            {
                Sunlight.transform.Rotate(Vector3.right*0.0333f);
            } 
            LightTime = Time.time;
        }

        if(Time.time- DateTime > 600f)
        {
            Time_Date();
        }
    }

    public static void Time_Date()
    {
        timer_date++;
        tc.timer_count.text = timer_date / 10 + "" + timer_date % 10;
        tc.DateTime = Time.time;
    }


}
