using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonToggle : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Sprite toggledOn;
    [SerializeField] private Sprite toggledOff;
    public GameObject mobileController;
    [SerializeField] private GameDataSO gameData;
    public Answer answer;
    public bool bStayOn = false;
    public bool isOn = false;

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

    public void Toggle()
    {
        if (bStayOn)
        {
            ToggleOn();
        }
        else
        {
            if (isOn)
                ToggleOff();
            else
                ToggleOn();
        }
    }

    public void ToggleOn()
    {
        isOn = true;
        image.sprite = toggledOn;
        if (mobileController != null)
            mobileController.SetActive(true);
        if (gameData != null)
            gameData.bMobileUIEnabled = true;
    }

    public void ToggleOff()
    {
        isOn = false;
        image.sprite = toggledOff;
        if (mobileController != null)
            mobileController.SetActive(false);
        if (gameData != null)
            gameData.bMobileUIEnabled = false;
    }
}
