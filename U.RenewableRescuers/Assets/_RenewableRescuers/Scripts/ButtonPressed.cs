using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool bIsDown = false;
    public bool bOnDown = false;
    private bool first = false;

    private void Update()
    {
        if (first)
        {
            bOnDown = true;
            first = false;
        }
        else
        {
            bOnDown = false;
        }
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        bIsDown = true;
        first = true;
    }
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData) => bIsDown = false;
}
