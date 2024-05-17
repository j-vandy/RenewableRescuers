using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Box")
            return;
        collision.gameObject.GetComponent<Box>().Return();
    }
}
