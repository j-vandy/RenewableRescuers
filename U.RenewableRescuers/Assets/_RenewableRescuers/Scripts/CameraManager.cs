using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FollowState
{
    Player
}

public class CameraManager : MonoBehaviour
{
    public const float SPEED = 5.0f;
    public FollowState followState;
    public Transform player;
    public Dictionary<FollowState, Transform> dict = new Dictionary<FollowState, Transform>();

    private void Start()
    {
        dict[FollowState.Player] = player;
    }


    private void FixedUpdate()
    {
        Transform target = dict[followState];
        float dist = Vector2.Distance(transform.position, target.position);
    }
}
