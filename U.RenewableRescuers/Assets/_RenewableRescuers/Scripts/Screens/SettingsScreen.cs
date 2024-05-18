using UnityEngine;
using System;

public class SettingsScreen : Screen
{
    [SerializeField] private Screen startScreen;
    [SerializeField] private GameDataSO gameData;
    [SerializeField] private ButtonToggle mobileUIToggle;

    private void Awake()
    {
        if (startScreen == null)
            throw new NullReferenceException();
        if (gameData == null)
            throw new NullReferenceException();
        if (mobileUIToggle == null)
            throw new NullReferenceException();
        if (mobileUIToggle.mobileController != null)
            mobileUIToggle.mobileController.SetActive(gameData.bMobileUIEnabled);
    }

    public override void Enable()
    {
        if (gameData.bMobileUIEnabled)
            mobileUIToggle.ToggleOn();
        else
            mobileUIToggle.ToggleOff();
        base.Enable();
    }

    public void OnMobileUIToggleChanged() => gameData.bMobileUIEnabled = mobileUIToggle.isOn;

    public void BackButtonClicked() => ScreenTransition(startScreen);
}
