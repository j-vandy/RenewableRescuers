using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    private float RAYCAST_DIST = 0.64f; // ensure RAY_DIST is greater than capsule collider
    private const float MOVEMENT_SPEED = 5f;
    private const float JUMP_FORCE = 375f;
    private const float JUMP_TIME_BUFFER_DURATION = 0.1f;
    private float jumpTime = 0;
    private bool bIsJumping = false;
    private Vector3 previous_pos;
    private Rigidbody2D _rigidbody;
    private PlayerAnimationController _animationController;
    public bool bCanMove = true;
    public static Action OnPlayerJump;
    public static Action OnPlayerLand;
    public SoundFX_Manager soundfx;
    [SerializeField] private MobileController mobileController;
    [SerializeField] private GameDataSO gameData;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        if (_rigidbody == null)
            throw new NullReferenceException();
        _animationController = GetComponent<PlayerAnimationController>();
        if (_animationController == null)
            throw new NullReferenceException();
        previous_pos = transform.position;
        if (mobileController == null)
            throw new NullReferenceException();
        if (gameData == null)
            throw new NullReferenceException();
    }

    private void Update()
    {
        // vertical movement
        bool bMovementKeyDown;
        if (gameData.bMobileUIEnabled)
            bMovementKeyDown = mobileController.jump_key_is_down;
        else 
            bMovementKeyDown = Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space);

        if (bMovementKeyDown && !bIsJumping)
        {
            soundfx.PlayPlayerJump();
            bIsJumping = true;
            jumpTime = Time.time;
            if (OnPlayerJump != null)
                OnPlayerJump();
            _rigidbody.AddForce(Vector2.up * JUMP_FORCE);
        }
    }

    private void FixedUpdate()
    {
        // ground check
        IsGrounded();

        // update x & y velocity
        Vector3 curr_pos = transform.position;
        Vector3 curr_velocity = (curr_pos - previous_pos) / Time.deltaTime;
        previous_pos = curr_pos;

        // update animation
        _animationController.UpdateAnimation(curr_velocity.x, curr_velocity.y, bIsJumping);

        // horizontal movement
        float input;
        Debug.Log(gameData.bMobileUIEnabled);
        if (gameData.bMobileUIEnabled)
            input = mobileController.horizontal_input;
        else
            input = Input.GetAxis(Utils.INPUT_AXIS_HORIZONTAL);
        float movement = input * MOVEMENT_SPEED * Time.deltaTime;
        transform.position += new Vector3(movement, 0f);
    }

    private void IsGrounded()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.down, RAYCAST_DIST);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.rigidbody == _rigidbody)
                continue;

            if (bIsJumping && Time.time - JUMP_TIME_BUFFER_DURATION > jumpTime)
            {
                if (OnPlayerLand != null)
                    OnPlayerLand();
            }
            bIsJumping = false;
            return;
        }
        bIsJumping = true;
    }
}
