using UnityEngine;
using Photon.Pun;
using System;

public class PlayerMovement : MonoBehaviour
{
    private const float RAYCAST_DIST = 1.1f; // ensure RAY_DIST is greater than capsule collider
    private const float MOVEMENT_SPEED = 5f;
    private const float JUMP_FORCE = 350f;
    private PhotonView _photonView;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _photonView = GetComponent<PhotonView>();
        if (_photonView == null) 
            throw new NullReferenceException();
        _rigidbody = GetComponent<Rigidbody2D>();
        if (_rigidbody == null) 
            throw new NullReferenceException();
    }

    private void Update()
    {
        if (!_photonView.IsMine)
            return;

        // vertical movement
        if (Input.GetButtonDown(Utils.INPUT_BUTTON_JUMP) && IsGrounded())
            _rigidbody.AddForce(Vector2.up * JUMP_FORCE);
    }

    private void FixedUpdate()
    {
        if (!_photonView.IsMine)
            return;

        // horizontal movement
        float input = Input.GetAxis(Utils.INPUT_AXIS_HORIZONTAL);
        float movement = input * MOVEMENT_SPEED * Time.deltaTime;
        transform.position += new Vector3(movement, 0f);
    }

    private bool IsGrounded()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.down, RAYCAST_DIST);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.rigidbody != _rigidbody)
                return true;
        }
        return false;
    }
}
