using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public static bool bGameOver = false;
    [SerializeField] private CameraFollow cameraFollow;
    [SerializeField] private EnergySwitch energySwitch;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Utils.TAG_RENEWABLE_TARGET)
        {
            if (bGameOver)
                return;
            cameraFollow.target = energySwitch.transform;
            energySwitch.PowerOn();
            bGameOver = true;
        }
    }
}
