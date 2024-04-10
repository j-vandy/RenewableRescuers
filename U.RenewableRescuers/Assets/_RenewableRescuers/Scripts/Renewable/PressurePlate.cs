using System;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    private int objectsInTrigger = 0;
    [SerializeField] private List<Powerable> connections = new List<Powerable>();
    [HideInInspector] public bool bIsOn = false;
    public SpriteRenderer spriteRenderer;

    private void Awake()
    {
        if (spriteRenderer == null)
            throw new NullReferenceException();
        if (connections.Count <= 0)
            Debug.LogWarning("Pressure plate has no connections");

        if (bIsOn)
            spriteRenderer.color = Color.green;
        else
            spriteRenderer.color = Color.red;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        objectsInTrigger++;
        bIsOn = true;
        foreach (var connection in connections)
            connection.PowerOn();
        spriteRenderer.color = Color.green;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        objectsInTrigger--;
        if (objectsInTrigger > 0)
            return;

        bIsOn = false;
        foreach (var connection in connections)
            connection.PowerOff();
        spriteRenderer.color = Color.red;
    }
}
