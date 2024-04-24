using UnityEngine;
using System;

public class PlayerAnimationController : MonoBehaviour
{
    private const float MIN_WALKING_SPEED = 0.1f;
    private float LANDING_TIME_BUFFER_DURATION;
    private Animator animator;
    private string currAnimationState;
    private float landingTime;

    private void OnEnable()
    {
        PlayerController.OnPlayerLand += Landed;
    }

    private void OnDisable()
    {
        PlayerController.OnPlayerLand -= Landed;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
            throw new NullReferenceException();

        foreach (var animClip in animator.runtimeAnimatorController.animationClips)
        {
            if (animClip.name == Utils.ANIMATION_PLAYER_LAND)
                LANDING_TIME_BUFFER_DURATION = animClip.length;
        }
        
        ChangeAnimationState(Utils.ANIMATION_PLAYER_IDLE);
    }

    private void Landed()
    {
        ChangeAnimationState(Utils.ANIMATION_PLAYER_LAND);
        landingTime = Time.time;
    }
    
    public void UpdateAnimation(float velocity_x, float velocity_y, bool bIsJumping)
    {
        // flip the player model
        if ((velocity_x > 0 && transform.localScale.x < 0) || (velocity_x < 0 && transform.localScale.x > 0))
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y);

        // switch animation to falling
        if (bIsJumping)
        {
            if (velocity_y < 0)
                ChangeAnimationState(Utils.ANIMATION_PLAYER_FALLING);
            else if (velocity_y > 0)
                ChangeAnimationState(Utils.ANIMATION_PLAYER_JUMP);
            else 
                ChangeAnimationState(Utils.ANIMATION_PLAYER_IDLE);
            return;
        }

        // ignore all animations until landing animation finishes playing
        if (Time.time - LANDING_TIME_BUFFER_DURATION > landingTime)
        {
            if (Mathf.Abs(velocity_x) > MIN_WALKING_SPEED)
                ChangeAnimationState(Utils.ANIMATION_PLAYER_WALK);
            else
                ChangeAnimationState(Utils.ANIMATION_PLAYER_IDLE);
        }
    }

    public void ChangeAnimationState(string newAnimationState)
    {
        if (currAnimationState == newAnimationState)
            return;
        
        animator.Play(newAnimationState);
        currAnimationState = newAnimationState;
    }
}
