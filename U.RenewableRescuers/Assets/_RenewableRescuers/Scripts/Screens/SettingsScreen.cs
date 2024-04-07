using UnityEngine;
using System;

public class SettingsScreen : Screen
{
    [SerializeField] private Screen startScreen;
    private void Awake()
    {
        if (startScreen == null)
            throw new NullReferenceException();
    }

    public void BackButtonClicked() => ScreenTransition(startScreen);
}
