using UnityEngine;

public class change_arms : MonoBehaviour
{
    public GameObject[] myArms;
    private int arms;
    // Start is called before the first frame update
    void Start()
    {

        arms = 0;
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            myArms = GameObject.FindGameObjectsWithTag("武器");
            print("現在拿" +myArms[arms]);
            arms++;
            if (arms== myArms.Length)
            {
                arms = 0;
            }
        }
    }
}
