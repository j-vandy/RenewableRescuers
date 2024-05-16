using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonToggle : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Sprite toggledOn;
    [SerializeField] private Sprite toggledOff;
    public Answer answer;

    // Start is called before the first frame update
    void Start()
    {
        if (image == null)
            throw new NullReferenceException();
        if (toggledOn == null)
            throw new NullReferenceException();
        if (toggledOff == null)
            throw new NullReferenceException();
    }

    public void ToggleOn() => image.sprite = toggledOn;
    public void ToggleOff() => image.sprite = toggledOff;
}
