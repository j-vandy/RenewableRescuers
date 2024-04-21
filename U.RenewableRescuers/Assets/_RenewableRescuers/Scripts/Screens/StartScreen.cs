using UnityEngine;
using System;

public class StartScreen : Screen
{
    [SerializeField] private Screen gameSelectScreen;
    [SerializeField] private Screen settingsScreen;
    [SerializeField] private Screen creditsScreen;

    void Awake()
    {
        if (gameSelectScreen == null)
            throw new NullReferenceException();
        if (settingsScreen == null)
            throw new NullReferenceException();
        if (creditsScreen == null)
            throw new NullReferenceException();
    }

    public void StartButtonClicked() => ScreenTransition(gameSelectScreen);

    public void SettingsButtonClicked() => ScreenTransition(settingsScreen);

    public void CreditsButtonClicked() => ScreenTransition(creditsScreen);

    public void QuitButtonClicked()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
