using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShieldDatabase : ScriptableObject
{
    public Shield[] shield;

    public int ShieldCount
    {
        get
        {
            return shield.Length;
        }
    }

    public Shield GetShield(int index)
    {
        return shield[index];
    }
}
