using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public const float SPEED = 5.0f;
    public bool bFollowTarget = false;
    // could take an array of targets
    public Transform target;

    private void FixedUpdate()
    {
        if (!bFollowTarget)
            return;
        else if (target == null)
            throw new NullReferenceException();

        Vector2 pos = Vector2.Lerp(transform.position, target.position, Utils.easeOutBack(SPEED * Time.deltaTime));
        transform.position = new Vector3(pos.x, pos.y, -10f);
    }
}
