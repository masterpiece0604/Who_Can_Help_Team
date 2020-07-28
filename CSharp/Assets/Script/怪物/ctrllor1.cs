﻿
using UnityEngine;
using System.Collections;

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
    public bool openbag;

    public bool NPC;
    public bool Introduce;

    private Rigidbody rig;


    //上一次點擊順移的時間
    private float lastTouchTime = 0f;


    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        look_at_point.transform.position = gameObject.transform.position;
        wait = true;
        run = false;
        openbag = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1) || Input.GetMouseButton(1))
        {
            if (NPC == false && Introduce == false)
            {
                ray = main_camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
                RaycastHit[] raycasthit = Physics.RaycastAll(ray, 50);

                for (int i = 0; i < raycasthit.Length; i++)
                {
                    if (raycasthit[i].collider.tag == "floor")
                    {
                        look_at_point.transform.position = raycasthit[i].point;
                        transform.LookAt(look_at_point.transform);
                        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
                        set_allstate_false();
                        run = true;

                    }
                    else if (raycasthit[i].collider.tag == "怪獸")
                    {
                        // this.transform.LookAt(monster.transform);
                        this.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
                        set_allstate_false();
                        run = true;
                    }

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

        //開啟玩家背包
        openplayerbag();
        playerbag.SetActive(openbag);

        MoveAddForce();
    }

    private void MoveAddForce()
    {

        if (Vector3.Distance(gameObject.transform.position, look_at_point.transform.position) > 2f)
        {
            transform.LookAt(look_at_point.transform);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            rig.AddForce(transform.forward * playerspeed);

        }
        else if (Vector3.Distance(gameObject.transform.position, look_at_point.transform.position) <1f)
        {
            rig.velocity = Vector3.zero;
        }


    }

    void moving(float speed)
    {
        // 加入順移功能
        var E_move = Input.GetKeyDown(KeyCode.E);
        var S_stand = Input.GetKeyDown(KeyCode.S);
        // 順移的冷卻時間
        var E_colling = false;

        // 順移判斷
        if (E_move)
        {
            //判斷冷卻時間
            E_colling = Set_Emove(E_colling);

            if (E_colling)
            {
                transform.Translate(new Vector3(0, 0, speed * Time.deltaTime + 3f), Space.Self);

                transform.LookAt(look_at_point.transform);
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

            }
        }

        if (S_stand)
        {
            Sstand();
        }

    }

    void set_allstate_false()
    {
        wait = false;
        run = false;
    }

    //設定玩家背包開關
    void openplayerbag()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            openbag = !openbag;

        }

    }

    public void closeBag()
    {
        openbag = !openbag;
    }

    public bool Set_Emove(bool E)
    {
        if (Time.realtimeSinceStartup - lastTouchTime > 3f)
        {
            lastTouchTime = Time.realtimeSinceStartup;
            E = true;
            return E;

        }
        else
        {
            E = false;
            return E;
        }



    }
    public void Sstand()
    {
        this.transform.LookAt(this.transform);
        this.transform.eulerAngles = new Vector3(0, this.transform.eulerAngles.y, 0);
        set_allstate_false();
    }

}
