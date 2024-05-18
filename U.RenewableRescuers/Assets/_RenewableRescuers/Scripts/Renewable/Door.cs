using System;
using UnityEngine;

public class Door : Powerable
{
    private Animator animator;
    private string currAnimationState;
    [SerializeField] private BoxCollider2D doorCollider;
    [SerializeField] private SoundFX_Manager sfx;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
            throw new NullReferenceException();
        if (doorCollider == null)
            throw new NullReferenceException();
        if (sfx == null)
            throw new NullReferenceException();

        currAnimationState = Utils.ANIMATION_DOOR_CLOSED;
    }

    private void ChangeAnimationState(string newAnimationState)
    {
        if (currAnimationState == newAnimationState)
            return;

        currAnimationState = newAnimationState;
        if (animator != null)
            animator.Play(newAnimationState);
    }

    public override void PowerOn()
    {
        doorCollider.enabled = false;
        ChangeAnimationState(Utils.ANIMATION_DOOR_ON_OPEN);
        sfx.PlayDoor();
        base.PowerOn();
    }

    public override void PowerOff()
    {
        if (doorCollider != null)
            doorCollider.enabled = true;
        ChangeAnimationState(Utils.ANIMATION_DOOR_ON_CLOSE);
        sfx.PlayDoor();
        base.PowerOff();
    }
}
