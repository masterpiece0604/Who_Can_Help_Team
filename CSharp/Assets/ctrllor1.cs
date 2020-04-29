
using UnityEngine;

public class ctrllor1 : MonoBehaviour
{

    public float playerspeed;
    public bool wait;
    public bool run;
    public Camera main_camera;
    public Ray ray;
    public GameObject look_at_point;

    
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
        

    }

    void moving(float speed)
    {
        transform.Translate(new Vector3(0, 0, playerspeed * Time.deltaTime), Space.Self);
    }

    void set_allstate_false()
    {
        wait = false;
        run = false;
    }
}
