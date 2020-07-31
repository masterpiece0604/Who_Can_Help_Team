using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NoviceHouse : MonoBehaviour
{
    [Header("新手小木屋對話")]
    public GameObject Natice_House;
    public Item Naticehouse;
    public bool textFinished;
    public float letterPause = 0.1f;
    private string word;
    public Text text;
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            CloseUI.Open_UI();
            Destroy(Natice_House);

        }

    }
    private void OnEnable()
    {

        StartCoroutine(SetTextUI());

    }
    public void PassNight()
    {
        if (Naticehouse.itemHold > 0)
        {
            time_count.Time_Date();
            Naticehouse.itemHold--;
            CloseUI.Open_UI();
            Destroy(Natice_House);
        }
    }


    public void Close()
    {
        CloseUI.Open_UI();
        Destroy(Natice_House);
    }

    IEnumerator SetTextUI()
    {
        word = text.text;
        text.text = "";

        foreach (char letter in word.ToCharArray())
        {  
            text.text += letter;
            yield return new WaitForSeconds(letterPause);
        }
    }  
}

