using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//新增滑鼠右鍵快捷
[CreateAssetMenu(fileName ="New Item" ,menuName = "Inventory/New Item")]
//ScriptableObject為可以儲存值的功能
public class Item : ScriptableObject
{
    [Header("道具名稱")]
    public string itemName;
    [Header("道具圖片")]
    public Sprite itemImage;
    [Header("道具持有數量")]
    public int itemHold;
    [Header("道具簡介")]
    [TextArea]
    public string itemInfo;

    public bool equipment;
    public bool use;
    public bool etc;
    public bool manufactur;
}
