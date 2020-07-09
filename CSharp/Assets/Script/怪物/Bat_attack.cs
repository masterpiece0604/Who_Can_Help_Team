using UnityEngine;
using static Monkey;

public class Bat_attack : MonoBehaviour
{
    [Header("丟擲物品")]
    public GameObject prop;

    [Header("預設攻擊路徑")]
    public GameObject preview;

    [Header("丟擲物品的CD")]
    public float cd;

    private float timer;

    private Vector3 Pre_position;

    private GameObject player;

    private float Pre_speed;
    private float Pre_rot;

    private bool is_atk = true;

    private Quaternion targetRotation;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        timer = cd;


    }

   
    void Update()
    {
        Throw();
    }

    private void Throw()
    {
        float dis = Vector3.Distance(transform.position, player.transform.position);

        if (dis <= gameObject.GetComponent<Animal>().attack_range)
        {
            timer += Time.deltaTime;
            

            if (timer >= cd)
            {
                is_atk = true;
                timer = 0;

                Pre_speed = gameObject.GetComponent<Monkey>().walkspeed;
                Pre_rot = gameObject.GetComponent<Monkey>().RotationSpeed;
                gameObject.GetComponent<Monkey>().walkspeed = 0;
                gameObject.GetComponent<Monkey>().RotationSpeed = 0;
                GameObject temp_P = Instantiate(preview, transform.position, Quaternion.identity);
                temp_P.transform.rotation = gameObject.transform.rotation;
                
                Destroy(temp_P, 0.8f);
                
                Invoke("Atk",1f);

                //temp.GetComponent<Rigidbody>().AddForce(new Vector3(150, 200, 0));

            }
            else if (is_atk == false)
            {
                targetRotation = Quaternion.LookRotation(player.transform.position-transform.position, Vector3.up);
                transform.rotation = Quaternion.Slerp(targetRotation, targetRotation, Pre_rot);
            }
        }
    }

    private void Atk()
    {
        GameObject temp = Instantiate(prop, transform.position + transform.forward + transform.up, Quaternion.identity);
        temp.GetComponent<Rigidbody>().AddForce(transform.forward * 1500);
        gameObject.GetComponent<Monkey>().walkspeed = Pre_speed;
        gameObject.GetComponent<Monkey>().RotationSpeed = Pre_rot;
        Destroy(temp, 0.8f);
        is_atk = false;
    }
}

