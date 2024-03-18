using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScreen : Screen
{
    [SerializeField] private Screen startScreen;
    private void Awake()
    {
        if (startScreen == null)
            Utils.DebugNullReference("CreditsScreen", "startScreen");
    }

    public void BackButtonClicked() => ScreenTransition(startScreen);
}
