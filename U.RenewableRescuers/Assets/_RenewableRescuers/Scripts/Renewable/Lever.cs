using System;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    private const float ON_MAX_ANGLE = 325;
    private const float ON_MIN_ANGLE = 270;
    private const float OFF_MAX_ANGLE = 90;
    private const float OFF_MIN_ANGLE = 35;
    [SerializeField] private Transform arm;
    [SerializeField] private List<Powerable> connections = new List<Powerable>();
    [HideInInspector] public bool bIsOff = false;
    [HideInInspector] public bool bIsOn = false;
    public SpriteRenderer spriteRenderer;

    private void Awake()
    {
        if (arm == null)
            throw new NullReferenceException();
        if (connections.Count <= 0)
            Debug.LogWarning("Lever has no connections");
    }

    private void Update()
    {
        float rot = arm.eulerAngles.z;

        if (ON_MIN_ANGLE < rot && rot < ON_MAX_ANGLE && !bIsOn)
        {
            bIsOn = true;
            bIsOff = false;
            foreach (var connection in connections)
                connection.PowerOn();

            spriteRenderer.color = Color.green;
        }
        if (OFF_MIN_ANGLE < rot && rot < OFF_MAX_ANGLE && !bIsOff)
        {
            bIsOff = true;
            bIsOn = false;
            foreach (var connection in connections)
                connection.PowerOff();

            spriteRenderer.color = Color.red;
        }
    }
}
