using UnityEngine;
using System;

public class StartScreen : Screen
{
    [SerializeField] private Screen loadingScreen;
    [SerializeField] private Screen lobbyScreen;
    [SerializeField] private Screen settingsScreen;
    [SerializeField] private Screen creditsScreen;

    void Awake()
    {
        if (loadingScreen == null)
            throw new NullReferenceException();
        if (lobbyScreen == null)
            throw new NullReferenceException();
        if (settingsScreen == null)
            throw new NullReferenceException();
        if (creditsScreen == null)
            throw new NullReferenceException();
    }

    public void StartButtonClicked()
    {
        ScreenTransition(loadingScreen);
        PhotonManager.Instance.ConnectUsingSettings();
    }

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
