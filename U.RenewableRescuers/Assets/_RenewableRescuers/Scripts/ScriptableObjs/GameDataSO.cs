using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[CreateAssetMenu]
public class GameDataSO : ScriptableObject
{
    public bool bIsHost = false;
    public bool bIsEddy = false;

    public void Print()
    {
        Debug.LogError("bIsHost: " + bIsHost);
        Debug.LogError("bIsEddy: " + bIsEddy);
    }
}
