using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class StartScreen : Screen
{
    [SerializeField] private Screen settingsScreen;
    [SerializeField] private Screen creditsScreen;

    void Awake()
    {
        if (settingsScreen == null)
            throw new NullReferenceException();
        if (creditsScreen == null)
            throw new NullReferenceException();
    }

    public void StartButtonClicked() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

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
