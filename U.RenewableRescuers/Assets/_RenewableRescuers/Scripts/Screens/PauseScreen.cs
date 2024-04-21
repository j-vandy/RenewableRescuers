using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PauseScreen : Screen
{
    [SerializeField] private PauseScreenController controller;
    [SerializeField] private Screen settingsScreen;
    [SerializeField] private Screen creditsScreen;

    void Awake()
    {
        if (controller == null)
            throw new NullReferenceException();
        if (settingsScreen == null)
            throw new NullReferenceException();
        if (creditsScreen == null)
            throw new NullReferenceException();
    }

    public void ResumeButtonClicked()
    {
        controller.bIsEnabled = false;
        Disable();
    }

    public void SettingsButtonClicked() => ScreenTransition(settingsScreen);

    public void CreditsButtonClicked() => ScreenTransition(creditsScreen);

    public void QuitButtonClicked() => SceneManager.LoadScene(Utils.SCENE_MAIN_MENU);
}
