using UnityEngine;

public class DropBanana : MonoBehaviour
{
    [Header("丟擲物品")]
    public GameObject prop;

    [Header("丟擲物品的CD")]
    public float cd;

    [Header("延遲攻擊")]
    public float delay;

    private float StartTime;

    private float timer;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
       
    }

    private void Update()
    {
        
            Throw();
       
        
    }

    private void Throw()
    {
       
        float dis = Vector3.Distance(transform.position, player.transform.position);

        if (dis <= gameObject.GetComponent<Animal>().attack_range)
        {
            
            timer += Time.deltaTime;
            StartTime += Time.deltaTime;
            if (StartTime >= delay)
            {
                if (timer >= cd)
                {
                    timer = 0;
                    GameObject temp = Instantiate(prop, transform.position, Quaternion.identity);
                    print(gameObject.name);
                    temp.GetComponent<Rigidbody>().AddForce(new Vector3(150, 200, 0));

                }
            }

        }
        else
        {
            StartTime = 0;
        }
        
    }
}
