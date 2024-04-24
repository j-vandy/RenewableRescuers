using System;
using UnityEngine;

public class Door : Powerable
{
    private Animator animator;
    private string currAnimationState;
    [SerializeField] private BoxCollider2D doorCollider;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
            throw new NullReferenceException();
        if (doorCollider == null)
            throw new NullReferenceException();

        currAnimationState = Utils.ANIMATION_DOOR_CLOSED;
    }

    private void ChangeAnimationState(string newAnimationState)
    {
        if (currAnimationState == newAnimationState)
            return;

        currAnimationState = newAnimationState;
        animator.Play(newAnimationState);
    }

    public override void PowerOn()
    {
        doorCollider.enabled = false;
        ChangeAnimationState(Utils.ANIMATION_DOOR_ON_OPEN);
        base.PowerOn();
    }

    public override void PowerOff()
    {
        doorCollider.enabled = true;
        ChangeAnimationState(Utils.ANIMATION_DOOR_ON_CLOSE);
        base.PowerOff();
    }
}
