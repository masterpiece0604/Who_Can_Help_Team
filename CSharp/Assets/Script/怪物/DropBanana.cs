using UnityEngine;

public class DropBanana : MonoBehaviour
{
    [Header("丟擲物品")]
    public GameObject prop;

        
    private float timer;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
       

    }
        

    public void Throw()
    {
       
        float dis = Vector3.Distance(transform.position, player.transform.position);

        if (dis <= gameObject.GetComponentInParent<Animal>().attack_range)
        {
            Invoke("DeleThrow", 0.5f);

        }
       
    }

    private void DeleThrow()
    {
            GameObject temp = Instantiate(prop, transform.position, Quaternion.identity);
                    
            temp.GetComponent<Rigidbody>().AddForce(new Vector3(150, 300, 0));
    }
}
