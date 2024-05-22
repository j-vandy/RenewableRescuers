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
    [SerializeField] private SolarPanel solarPanel;
    [SerializeField] private GameObject errorMessage;
    [SerializeField] private GameObject correctMessage;
    [SerializeField] private SoundFX_Manager soundfx_manager;
    [SerializeField] private ButtonToggle a;
    [SerializeField] private ButtonToggle b;
    [SerializeField] private ButtonToggle c;
    [SerializeField] private Button confirmButton;
    public Answer answer;

    private void Start()
    {
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
            soundfx_manager.PlayWrong();
            return;
        }
        else
        {
            Delete d = Instantiate(correctMessage, Vector3.zero, Quaternion.identity).GetComponent<Delete>();
            d.leverQuestion = this;
            soundfx_manager.PlayCorrect();
        }
    }

    public void Close()
    {
        // unlock the lever
        if (lever != null)
            lever.Unlock();
        else
            solarPanel.Unlock();

        Utils.UnfreezeTime();
        gameObject.SetActive(false);
    }

    private void SetSelection(ButtonToggle selected)
    {
        soundfx_manager.PlayUI();
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
    }

    public void OnAnswerAClicked() => SetSelection(a);
    public void OnAnswerBClicked() => SetSelection(b);
    public void OnAnswerCClicked() => SetSelection(c);
    public void OnConfirmClicked() => CheckAnswer();
}
