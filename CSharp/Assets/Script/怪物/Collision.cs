using UnityEngine;


public class Collision : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(8, 9);
    }

    
}
