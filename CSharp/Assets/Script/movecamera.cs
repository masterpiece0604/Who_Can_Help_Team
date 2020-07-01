using UnityEngine;

public class movecamera : MonoBehaviour
{
    public GameObject player;
    public float mouse_scroll;
    public float m_total;

    // Start is called before the first frame update
    void Start()
    {
        mouse_scroll = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);

        mouse_scroll = Input.GetAxis("Mouse ScrollWheel");
        if (mouse_scroll != 0)
        {
            m_total += mouse_scroll;
            if (m_total > 3 || m_total <= -0.01)
            {
                m_total -= mouse_scroll;
                mouse_scroll = 0;
                
            }


            transform.Translate(new Vector3(0, 0, mouse_scroll * Time.deltaTime * 500f), Space.Self);
        }
    }
}
