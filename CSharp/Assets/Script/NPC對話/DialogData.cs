using UnityEngine;

[CreateAssetMenu(menuName = "KID/DialogData", fileName = "對話資料")]
public class DialogData : ScriptableObject
{
    public Dialog[] dialogs;
}

[System.Serializable]
public struct Dialog
{
    /// <summary>
    /// 說話的人
    /// </summary>
    public string person;
    
    [TextArea(5, 10)]
    /// <summary>
    /// 對話內容
    /// </summary>
    public string dialog;
}