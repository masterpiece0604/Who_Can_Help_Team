using UnityEngine;

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

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
                timer = 0;
                GameObject temp_P = Instantiate(preview, transform.position , Quaternion.identity);
                temp_P.GetComponent<ParticleSystem>().gameObject.transform.rotation = transform.rotation;
                Pre_position = transform.position;
                Invoke("atk",2f);

                //temp.GetComponent<Rigidbody>().AddForce(new Vector3(150, 200, 0));

            }
        }
    }

    private void atk()
    {
        GameObject temp = Instantiate(prop, transform.position + transform.forward + transform.up, Quaternion.identity);
        temp.GetComponent<Rigidbody>().AddForce(transform.forward * 1500);
    }
}

