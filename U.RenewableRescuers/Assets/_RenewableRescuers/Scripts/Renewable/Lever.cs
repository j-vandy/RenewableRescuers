using System;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System.Runtime.CompilerServices;

public class Lever : MonoBehaviour
{
    private Animator animator;
    private string currAnimationState;
    private bool bIsOn = false;
    private bool bOpeningQuestionBox = false;
    private float time_since_open_start = 0f;
    private float QUESTION_OPEN_TIME_DURATION;
    [SerializeField] private bool bIsLocked = true;
    [ShowIf("bIsLocked")]
    [SerializeField] private GameObject leverQuestion;
    [SerializeField] private List<Powerable> connections = new List<Powerable>();

    private void Awake()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
            throw new NullReferenceException();
        if (bIsLocked && leverQuestion == null)
            throw new NullReferenceException();
        if (connections.Count <= 0)
            Debug.LogWarning("Lever has no connections");

        // set "animation" to locked or unlocked
        if (bIsLocked)
            ChangeAnimationState(Utils.ANIMATION_LEVER_LOCKED);
        else
            ChangeAnimationState(Utils.ANIMATION_LEVER_UNLOCKED);

        foreach (var animClip in animator.runtimeAnimatorController.animationClips)
        {
            if (animClip.name == Utils.ANIMATION_LEVER_QUESTION_OPEN)
                QUESTION_OPEN_TIME_DURATION = animClip.length;
        }
    }

    private void Update()
    {
        if (bOpeningQuestionBox)
        {
            time_since_open_start += Time.deltaTime;
            if (time_since_open_start >= QUESTION_OPEN_TIME_DURATION)
            {
                leverQuestion.SetActive(true);
                Utils.FreezeTime();
                bOpeningQuestionBox = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!bIsLocked)
                Toggle();
            else
            {
                // open questionnaire box
                ChangeAnimationState(Utils.ANIMATION_LEVER_QUESTION_OPEN);
                bOpeningQuestionBox = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && bOpeningQuestionBox)
        {
            ChangeAnimationState(Utils.ANIMATION_LEVER_QUESTION_CLOSE);
            bOpeningQuestionBox = false;
            time_since_open_start = 0;
        }
    }

    private void ChangeAnimationState(string newAnimationState)
    {
        if (currAnimationState == newAnimationState)
            return;

        animator.Play(newAnimationState);
        currAnimationState = newAnimationState;
    }

    private void Toggle()
    {
        // toggle the switch state
        bIsOn = !bIsOn;

        // change animation states
        if (bIsOn)
            ChangeAnimationState(Utils.ANIMATION_LEVER_TOGGLE_ON);
        else 
            ChangeAnimationState(Utils.ANIMATION_LEVER_TOGGLE_OFF);

        // power on/off connections
        foreach (var connection in connections)
        {
            if (bIsOn)
                connection.PowerOn();
            else
                connection.PowerOff();
        }
    }

    public void Unlock()
    {
        Utils.UnfreezeTime();
        bIsLocked = false;
        Toggle();
    }
}
