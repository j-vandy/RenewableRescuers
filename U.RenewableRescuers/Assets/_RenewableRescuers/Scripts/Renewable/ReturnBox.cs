using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Box")
        {
            collision.gameObject.GetComponent<Box>().Return();
        }
        else if (collision.tag == Utils.TAG_REFLECT)
        {
            collision.gameObject.GetComponent<Reflection>().Return();
        }
        else if (collision.tag == Utils.TAG_SOLAR)
        {
            collision.gameObject.GetComponentInChildren<SolarPanel>().Return();
        }
    }
}
