using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemInfoImageMove : MonoBehaviour
{
    public Text infoText;
    public GameObject infoImage;
    public int infoImageX;
    public int infoImageY;

    private void Update()
    {
        if(infoText.text == "")
        {
            infoImage.SetActive(false);
        }
        else
        {
            infoImage.SetActive(true);
            infoImage.transform.position = new Vector3(Input.mousePosition.x + infoImageX, Input.mousePosition.y + infoImageY, Input.mousePosition.z);
        }
    }
}
