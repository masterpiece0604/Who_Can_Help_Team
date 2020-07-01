using UnityEngine;

public class Role_quality : MonoBehaviour
{
    /// <summary>
    /// 主角的健康
    /// </summary>
    [Header("主角的健康"), Tooltip("如果小於100會變成染疫值")]
    public float health;

    /// <summary>
    /// 主角的飢餓度
    /// </summary>
    [Header("主角飢餓度")]
    public float hungry;

    /// <summary>
    /// 主角的罪惡感
    /// </summary>
    [Header("主角罪惡感")]
    public float guilt;
    /// <summary>
    /// 主角目前手持武器
    /// </summary>
    [Header("主角目前手持武器")]
    public GameObject prop;


    

   
}
