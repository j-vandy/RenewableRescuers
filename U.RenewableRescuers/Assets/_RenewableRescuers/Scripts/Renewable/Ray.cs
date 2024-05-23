using UnityEngine;
using System;

public class Ray : MonoBehaviour
{
    [SerializeField] private CameraFollow cameraFollow;
    [SerializeField] private Transform spriteTransform;
    [SerializeField] private EnergySwitch energySwitch;
    public LayerMask layerToCollide;
    private bool bFin = false;
    private GameObject solarHit = null;
    private GameObject reflection = null;

    private void Start()
    {
        Physics2D.queriesHitTriggers = false;
        if (spriteTransform == null)
            throw new NullReferenceException();
        if (cameraFollow == null)
            throw new NullReferenceException();
    }

    public void NoHit()
    {
        if (solarHit != null)
        {
            solarHit.GetComponentInChildren<SolarPanel>().PowerOff();
            solarHit = null;
        }
        if (reflection != null)
        {
            reflection.GetComponent<Reflection>().PowerOff();
            reflection = null;
        }
    }

    private void Update()
    {
        if (bFin)
            return;

        // shoot out a ray down the x-axis
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, float.MaxValue, layerToCollide);
        if (hit)
        {
            // end level if ray meets renewable target
            if (hit.transform.tag == Utils.TAG_RENEWABLE_TARGET)
            {
                // link stuff
                cameraFollow.target = energySwitch.transform;
                energySwitch.PowerOn();
                bFin = true;
            }
            else if (hit.transform.tag == Utils.TAG_SOLAR)
            {
                if (reflection != null)
                {
                    reflection.GetComponent<Reflection>().PowerOff();
                    reflection = null;
                }
                if (hit.transform.gameObject != solarHit)
                {
                    if (solarHit != null)
                    {
                        solarHit.GetComponentInChildren<SolarPanel>().PowerOff();
                        solarHit = null;
                    }
                    GameObject go = hit.transform.gameObject;
                    SolarPanel solar_panel= go.GetComponentInChildren<SolarPanel>();
                    if (!solar_panel.isLocked)
                    {
                        solarHit = go;
                        solar_panel.PowerOn();
                    }
                }
            }
            else if (hit.transform.tag == Utils.TAG_REFLECT)
            {
                if (solarHit != null)
                {
                    solarHit.GetComponentInChildren<SolarPanel>().PowerOff();
                    solarHit = null;
                }
                if (hit.transform.gameObject != reflection)
                {
                    if (reflection != null)
                    {
                        reflection.GetComponent<Reflection>().PowerOff();
                        reflection = null;
                    }
                    reflection = hit.transform.gameObject;
                    reflection.GetComponent<Reflection>().PowerOn();
                }
                else
                {
                    if (!reflection.GetComponent<Reflection>().isActive)
                        reflection.GetComponent<Reflection>().PowerOn();
                }
            }
            else
            {
                NoHit();
            }

            // update ray render
            Vector3 hitPoint = new Vector3(hit.point.x, hit.point.y, 0f);
            Vector3 localHitPoint = hitPoint - transform.position;
            Vector3 midpoint = transform.position + (localHitPoint / 2);
            Vector3 scale = new Vector3(localHitPoint.magnitude, 1f, 1f);
            spriteTransform.position = midpoint;
            spriteTransform.localScale = scale;
        }
    }
}
