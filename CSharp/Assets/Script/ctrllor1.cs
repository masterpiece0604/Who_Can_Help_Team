
using UnityEngine;

public class ctrllor1 : MonoBehaviour
{

    public float playerspeed;
    public bool wait;
    public bool run;
    public Camera main_camera;
    public Ray ray;
    public GameObject look_at_point;
    [Header("玩家背包")]
    public GameObject playerbag;
    bool openbag;

    //上一次點擊順移的時間
    private float lastTouchTime = 0f;


    // Start is called before the first frame update
    void Start()
    {
        playerspeed = 3f;
        wait = true;
        run = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) || Input.GetMouseButton(1))
        {
            ray = main_camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit[] raycasthit = Physics.RaycastAll(ray, 50);

            for (int i = 0; i < raycasthit.Length; i++)
            {
                if (raycasthit[i].collider.tag == "floor")
                {
                    look_at_point.transform.position = raycasthit[i].point;
                    this.transform.LookAt(look_at_point.transform);
                    this.transform.eulerAngles = new Vector3(0, this.transform.eulerAngles.y, 0);
                    set_allstate_false();
                    run = true;

                }

            }
            
        }

       

        if (run == true)
        {
            if (Mathf.Abs(transform.position.x - look_at_point.transform.position.x) < 0.1f && Mathf.Abs(transform.position.z - look_at_point.transform.position.z) < 0.1f)
            {
                set_allstate_false();
                wait = true;
            }

            else
            {
                moving(playerspeed);
            }
            
        
        }

        openplayerbag();



    }

    void moving(float speed)
    {
        // 加入順移功能
        var E_move = Input.GetKeyDown(KeyCode.E);
        // 順移的冷卻時間
        var E_colling = false;

        // 順移判斷
        if (E_move)
        {
            //判斷冷卻時間
            E_colling=Set_Emove(E_colling);

            if(E_colling)
            {
                transform.Translate(new Vector3(0, 0, speed * Time.deltaTime + 3f), Space.Self);

            }
            else
            {
                print("正在冷卻中"+ Time.realtimeSinceStartup+"上次時間"+ lastTouchTime);
            }

        }
        else
        {
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime), Space.Self);
        }

    }

    void set_allstate_false()
    {
        wait = false;
        run = false;
    }


    void openplayerbag()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            openbag = !openbag;
            playerbag.SetActive(openbag);
        }

    }


   public bool Set_Emove(bool E)
    {
        if(Time.realtimeSinceStartup-lastTouchTime>3f)
         {
            lastTouchTime = Time.realtimeSinceStartup;
            E = true;
            return E ;

        }
        else
        {
            E = false;
            return E;
        }
        


    }

}
