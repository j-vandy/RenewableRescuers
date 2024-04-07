using UnityEngine;
using System;

public class CreditsScreen : Screen
{
    [SerializeField] private Screen startScreen;
    private void Awake()
    {
        if (startScreen == null)
            throw new NullReferenceException();
    }

    public void BackButtonClicked() => ScreenTransition(startScreen);
}
