using System;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    private int objectsInTrigger = 0;
    [SerializeField] private SoundFX_Manager soundfx;
    [SerializeField] private List<Powerable> connections = new List<Powerable>();
    [HideInInspector] public bool bIsOn = false;

    private void Awake()
    {
        if (soundfx == null)
            throw new NullReferenceException();
        if (connections.Count <= 0)
            Debug.LogWarning("Pressure plate has no connections");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (objectsInTrigger == 0)
            soundfx.PlayLever();

        objectsInTrigger++;
        bIsOn = true;
        foreach (var connection in connections)
            connection.PowerOn();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        objectsInTrigger--;
        if (objectsInTrigger > 0)
            return;


        soundfx.PlayLever();

        bIsOn = false;
        foreach (var connection in connections)
            connection.PowerOff();
    }
}
