using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public struct PlayData
{
    public Vector3 pos;
    public Inventory bag;
    public float health, hungry, guilt, sick;
}
