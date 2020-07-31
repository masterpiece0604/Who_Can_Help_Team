using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CloseUI : MonoBehaviour
{
    static CloseUI closeUI;

    public GameObject UI;
    

    private void Start()
    {
        closeUI = this;
    }
    public static void Open_UI()
    {
        closeUI.UI.SetActive(true);
    }

    public static void Close_UI()
    {
        closeUI.UI.SetActive(false);
    }

   
}
