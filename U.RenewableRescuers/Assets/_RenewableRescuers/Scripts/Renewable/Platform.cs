using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System.Security.Cryptography;
using Unity.VisualScripting.Dependencies.Sqlite;
using Unity.VisualScripting;

public class Platform : Powerable
{
    public int targetIndex = 0;
    public int currentIndex = 0;
    public bool bLoop = false;
    public bool bReturnToStart = true;
    public float speed = 5.0f;
    public List<Transform> targetPositions = new List<Transform>();

    private void Start()
    {
        string name = gameObject.name + " - targetPosition (" + targetPositions.Count + ")";
        GameObject go = new GameObject(name);
        go.transform.position = transform.position;
        targetPositions.Insert(0, go.transform);
    }

    private void FixedUpdate()
    {
        MoveTowardsTarget();
    }

    private void MoveTowardsTarget()
    {
        if (!bIsOn && !bReturnToStart)
            return;
        if (bIsOn && !bLoop && currentIndex == targetPositions.Count - 1)
        {
            if (Vector3.Distance(transform.position, targetPositions[currentIndex].position) > 0.1)
            {
                targetIndex = targetPositions.Count - 1;
                currentIndex = targetIndex - 1;
            }
            else
                return;
        }
        if (!bIsOn && bReturnToStart && currentIndex == 0)
        {
            if (Vector3.Distance(transform.position, targetPositions[0].position) > 0.1)
            {
                targetIndex = 0;
                currentIndex = 1;
            }
            else
                return;
        }

        // move towards the target position
        float dist = Vector3.Distance(transform.position, targetPositions[targetIndex].position);
        float t = Time.deltaTime / (dist / speed);
        Mathf.Clamp01(t);
        transform.position = Vector3.Lerp(transform.position, targetPositions[targetIndex].position, t);

        // update the current and target index
        if (t >= 0.99)
        {
            currentIndex = targetIndex;
            if (bIsOn)
            {
                if (targetIndex == targetPositions.Count - 1)
                {
                    if (bLoop)
                        targetIndex = 0;
                    else
                        targetIndex--;
                }
                else
                    targetIndex++;
            }
            else
            {
                if (targetIndex == 0)
                    targetIndex++;
                else
                    targetIndex--;
            }
        }
    }

    [Button]
    public void AddTargetPosition()
    {
        string name = "targetPosition (" + (targetPositions.Count+1) + ")";
        GameObject go = new GameObject(name);
        go.transform.position = transform.position;
        go.transform.localScale = Vector3.one;
        targetPositions.Add(go.transform);
    }
}
