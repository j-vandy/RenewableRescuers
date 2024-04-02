using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[CreateAssetMenu]
public class GameDataSO : ScriptableObject
{
    public bool bIsHost = false;
    public bool bIsEddy = false;
    public bool bReturnToJoinRoomScreen = false;

    public void ResetValues()
    {
        bIsHost = false;
        bIsEddy = false;
        bReturnToJoinRoomScreen = false;
    }

    public void Print()
    {
        Debug.LogError("bIsHost: " + bIsHost);
        Debug.LogError("bIsEddy: " + bIsEddy);
        Debug.LogError("bReturnToJoinRoomScreen: " + bReturnToJoinRoomScreen);
    }
}
