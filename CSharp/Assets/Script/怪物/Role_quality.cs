using UnityEngine;
using UnityEngine.UI;

public class Role_quality : MonoBehaviour
{
    /// <summary>
    /// 主角的健康
    /// </summary>
    [Header("主角的健康"), Tooltip("如果小於100會變成染疫值")]
    public float health;
    [Header("主角的健康物件")]
    public Text healthObject;

    /// <summary>
    /// 主角的飢餓度
    /// </summary>
    [Header("主角飢餓度")]
    public float hungry;
    [Header("主角飢餓度物件")]
    public Text hungryObject;

    /// <summary>
    /// 主角的罪惡感
    /// </summary>
    [Header("主角罪惡感")]
    public float guilt;
    [Header("主角罪惡感物件")]
    public Text guiltObject;
    /// <summary>
    /// 主角目前手持武器
    /// </summary>
    [Header("主角目前手持武器")]
    public GameObject prop;

    [Header("主角染疫物件")]
    public float sick;
    [Header("主角染疫物件")]
    public Text sickObject;

   


    private void Update()
    {
       
        healthObject.text = health + "";
        hungryObject.text = hungry + "";
        guiltObject.text = guilt + "";
        sickObject.text = sick + "";
    }

   


}
