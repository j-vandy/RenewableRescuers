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
    [SerializeField] private List<float> connections;
    [HideInInspector] public bool bIsOff = false;
    [HideInInspector] public bool bIsOn = false;
    public Action OnLeverTurnedOn;
    public Action OnLeverTurnedOff;

    public SpriteRenderer spriteRenderer;

    private void Awake()
    {
        if (arm == null)
            throw new NullReferenceException();
    }

    private void Update()
    {
        float rot = arm.eulerAngles.z;

        if (ON_MIN_ANGLE < rot && rot < ON_MAX_ANGLE && !bIsOn)
        {
            bIsOn = true;
            bIsOff = false;
            if (OnLeverTurnedOn != null)
                OnLeverTurnedOn();

            spriteRenderer.color = Color.green;
        }
        if (OFF_MIN_ANGLE < rot && rot < OFF_MAX_ANGLE && !bIsOff)
        {
            bIsOff = true;
            bIsOn = false;
            if (OnLeverTurnedOff != null)
                OnLeverTurnedOff();

            spriteRenderer.color = Color.red;
        }
    }
}
