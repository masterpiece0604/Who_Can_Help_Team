using UnityEngine;

public class cam_ref : MonoBehaviour
{
    public GameObject player;
    
    void Update()
    {
        Vector3 posP = player.transform.position;

        //posP.x = Mathf.Clamp(posP.x, 10, 90);
        //posP.z = Mathf.Clamp(posP.z, 17, 92);

        transform.position = posP;
    }
}
