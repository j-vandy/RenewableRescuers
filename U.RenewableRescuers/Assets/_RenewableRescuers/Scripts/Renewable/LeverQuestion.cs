using UnityEngine;
using System;

public enum Answer
{
    A, B, C, D
}

public class LeverQuestion : MonoBehaviour
{
    [SerializeField] private Lever lever;
    public Answer answer;

    private void Start()
    {
        if (lever == null)
            throw new NullReferenceException();
    }

    private void CheckAnswer(Answer input_answer)
    {
        if (input_answer == answer)
        {
            lever.Unlock();
            gameObject.SetActive(false);
        }
    }

    public void OnAnswerAClicked() => CheckAnswer(Answer.A);
    public void OnAnswerBClicked() => CheckAnswer(Answer.B);
    public void OnAnswerCClicked() => CheckAnswer(Answer.C);
    public void OnAnswerDClicked() => CheckAnswer(Answer.D);
}
