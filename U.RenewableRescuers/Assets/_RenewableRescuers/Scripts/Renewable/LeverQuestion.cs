using UnityEngine;
using UnityEngine.UI;
using System;

public enum Answer
{
    A, B, C
}

public class LeverQuestion : MonoBehaviour
{
    private ButtonToggle selectedAnswer = null;
    [SerializeField] private Lever lever;
    [SerializeField] private GameObject errorMessage;
    [SerializeField] private ButtonToggle a;
    [SerializeField] private ButtonToggle b;
    [SerializeField] private ButtonToggle c;
    [SerializeField] private Button confirmButton;
    public Answer answer;

    private void Start()
    {
        if (lever == null)
            throw new NullReferenceException();
        if (a == null)
            throw new NullReferenceException();
        if (b == null)
            throw new NullReferenceException();
        if (c == null)
            throw new NullReferenceException();
        if (confirmButton == null)
            throw new NullReferenceException();
    }

    private void CheckAnswer()
    {
        if (selectedAnswer.answer != answer)
        {
            Instantiate(errorMessage, Vector3.zero, Quaternion.identity);
            // play an error message audio
            return;
        }

        // unlock the lever
        lever.Unlock();
        gameObject.SetActive(false);
    }

    private void SetSelection(ButtonToggle selected)
    {
        if (selectedAnswer == null)
        {
            selectedAnswer = selected;
            confirmButton.interactable = true;
            return;
        }

        if (selected.answer == selectedAnswer.answer)
            return;

        selectedAnswer.ToggleOff();
        selectedAnswer = selected;
        // probably add a sound effect
    }

    public void OnAnswerAClicked() => SetSelection(a);
    public void OnAnswerBClicked() => SetSelection(b);
    public void OnAnswerCClicked() => SetSelection(c);
    public void OnConfirmClicked() => CheckAnswer();
}
