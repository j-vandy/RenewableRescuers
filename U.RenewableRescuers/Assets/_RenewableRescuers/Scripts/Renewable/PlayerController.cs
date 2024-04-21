using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float RAYCAST_DIST = 0.6f; // ensure RAY_DIST is greater than capsule collider
    private const float MOVEMENT_SPEED = 5f;
    private const float JUMP_FORCE = 350f;
    private Rigidbody2D _rigidbody;
    public static Action OnRestart;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        if (_rigidbody == null)
            throw new NullReferenceException();
    }

    private void Update()
    {
        // vertical movement
        bool movementKeyDown = Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W);
        if (movementKeyDown && IsGrounded())
            _rigidbody.AddForce(Vector2.up * JUMP_FORCE);

        // reset the game on reset pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (OnRestart != null)
                OnRestart();
        }
    }

    private void FixedUpdate()
    {
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
