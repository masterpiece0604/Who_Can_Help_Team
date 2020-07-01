using UnityEngine;

public class Repect_appear : MonoBehaviour
{
    public GameObject monster;
    // Start is called before the first frame update
    public void re_appear()
    {
        float x;
        float z;

        x = Random.Range(transform.position.x, transform.position.x + 5f);
        // 隨機生成X座標，範圍空物件的+5f內

        z = Random.Range(transform.position.z, transform.position.z + 5f);
        // 隨機生成Z座標，範圍(30~35)

        Instantiate(monster, new Vector3(x, 1.3f, z), Quaternion.identity);
    }

   
}
