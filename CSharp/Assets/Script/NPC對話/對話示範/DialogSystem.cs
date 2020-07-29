using UnityEngine;

public class DialogSystem : MonoBehaviour
{
    public DialogData data;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            print(data.dialogs[0].person);
            print(data.dialogs[0].dialog);
        }
    }
}
