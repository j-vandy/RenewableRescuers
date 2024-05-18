using UnityEngine;
using System;

public class GameDataInit : MonoBehaviour
{
    [SerializeField] private GameDataSO gameData;

    void Start()
    {
        if (gameData == null)
            throw new NullReferenceException();
        gameData.bIsMobileDevice = SystemInfo.deviceType == DeviceType.Handheld;
        if (!gameData.bMobileUIEnabled)
            gameData.bMobileUIEnabled = gameData.bIsMobileDevice;
        gameData.time = 0f;
    }
}
