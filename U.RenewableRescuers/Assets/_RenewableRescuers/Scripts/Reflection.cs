using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflection : MonoBehaviour
{
    public bool isActive = false;
    [SerializeField] private GameObject ray;

    private void Start()
    {
        if (isActive)
            PowerOn();
        else
            PowerOff();
    }
    public void PowerOn()
    {
        ray.SetActive(true);
    }
    public void PowerOff()
    {
        ray.SetActive(false);
    }
}
