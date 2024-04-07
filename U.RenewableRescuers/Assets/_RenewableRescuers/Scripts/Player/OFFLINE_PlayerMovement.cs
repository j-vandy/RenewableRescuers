using System;
using UnityEngine;

public class OFFLINE_PlayerMovement : MonoBehaviour
{
    private const float RAYCAST_DIST = 1.1f; // ensure RAY_DIST is greater than capsule collider
    private const float MOVEMENT_SPEED = 5f;
    private const float JUMP_FORCE = 350f;
    private Rigidbody2D _rigidbody;
    public bool bUsesArrows = false;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        if (_rigidbody == null)
            throw new NullReferenceException();
    }

    private void Update()
    {
        // vertical movement
        bool keyDown = bUsesArrows ? Input.GetKeyDown(KeyCode.UpArrow) : Input.GetKeyDown(KeyCode.W);
        if (keyDown && IsGrounded())
            _rigidbody.AddForce(Vector2.up * JUMP_FORCE);
    }

    private void FixedUpdate()
    {
        // horizontal movement
        float input = 0;
        if (bUsesArrows)
        {
            input = Input.GetKey(KeyCode.LeftArrow) ? input - 1 : input;
            input = Input.GetKey(KeyCode.RightArrow) ? input + 1 : input;
        }
        else
        {
            input = Input.GetKey(KeyCode.A) ? input - 1 : input;
            input = Input.GetKey(KeyCode.D) ? input + 1 : input;
        }
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
