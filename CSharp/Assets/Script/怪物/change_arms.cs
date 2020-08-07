using UnityEngine;

public class change_arms : MonoBehaviour
{
    public GameObject[] myArms;
    private int arms;

    /// <summary>
    /// 排序武器順序
    /// </summary>
    void ArrayArms()
    {
        GameObject a;
        for (int i = 0; i < myArms.Length - 1; i++)
        {
            
            if (myArms[i].name == "美工刀")
            {
                a = myArms[0];
                myArms[0] = myArms[i];
                myArms[i] = a;

            }
            else if (myArms[i].name == "斧")
            {
                a = myArms[1];
                myArms[1] = myArms[i];
                myArms[i] = a;

            }
            else if (myArms[i].name == "鎬")
            {
                a = myArms[2];
                myArms[2] = myArms[i];
                myArms[i] = a;

            }
            else if (myArms[i].name == "鋸子")
            {
                a = myArms[3];
                myArms[3] = myArms[i];
                myArms[i] = a;

            }
            else if (myArms[i].name == "飛鏢")
            {
                a = myArms[4];
                myArms[4] = myArms[i];
                myArms[i] = a;

            }
        }
        for (int i = 0; i < myArms.Length; i++)
        {
            myArms[i].SetActive(false);

        }



    }


    void Start()
    {

        arms = 0;
        myArms = GameObject.FindGameObjectsWithTag("武器");
        ArrayArms();
        gameObject.GetComponent<Role_quality>().prop = myArms[arms];
        myArms[arms].SetActive(true);

    }

    

// Update is called once per frame
void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject NowArm;
            NowArm = myArms[arms];
            if(arms==4)
            {
                NowArm.SetActive(false);
                arms = 0;
                myArms[arms].SetActive(true);
                gameObject.GetComponent<Role_quality>().prop = myArms[arms];
                gameObject.GetComponent<Role_attak>().ArmsAttak = myArms[arms].GetComponent<Arms>().ArmAttack;


            }
            else
            {
                for (int i = 1; arms + i < myArms.Length; i++)
                {
                    if (myArms[arms + i].GetComponent<Arms>().Durability > 0)
                    {
                        NowArm.SetActive(false);
                        arms = arms + i;
                        myArms[arms].SetActive(true);
                        gameObject.GetComponent<Role_quality>().prop = myArms[arms];
                        gameObject.GetComponent<Role_attak>().ArmsAttak = myArms[arms].GetComponent<Arms>().ArmAttack;
                        break;
                    }
                    else if (arms + i == 4)
                    {
                        NowArm.SetActive(false);
                        arms = 0;
                        myArms[arms].SetActive(true);
                        gameObject.GetComponent<Role_quality>().prop = myArms[arms];
                        gameObject.GetComponent<Role_attak>().ArmsAttak = myArms[arms].GetComponent<Arms>().ArmAttack;
                        break;
                    }

                }
            }
            /*for (int i = 1; arms + i < myArms.Length; i++)
            {
                if (myArms[arms + i].GetComponent<Arms>().Durability > 0)
                {
                    NowArm.SetActive(false);
                    arms = arms + i;
                    myArms[arms].SetActive(true);
                    gameObject.GetComponent<Role_quality>().prop = myArms[arms];

                    break;
                }
                else if(arms + i == 4)
                {
                    NowArm.SetActive(false);
                    arms = 0;
                    myArms[arms].SetActive(true);
                    gameObject.GetComponent<Role_quality>().prop = myArms[arms];
                    break;
                }

            }*/

        }
    }
}