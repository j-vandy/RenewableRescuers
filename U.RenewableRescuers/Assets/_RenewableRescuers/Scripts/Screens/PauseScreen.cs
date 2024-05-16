using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PauseScreen : Screen
{
    [SerializeField] private PauseScreenController controller;
    [SerializeField] private Screen settingsScreen;

    void Awake()
    {
        if (controller == null)
            throw new NullReferenceException();
        if (settingsScreen == null)
            throw new NullReferenceException();
    }

    public void ResumeButtonClicked()
    {
        controller.bIsEnabled = false;
        Utils.UnfreezeTime();
        Disable();
    }

    public void SettingsButtonClicked() => ScreenTransition(settingsScreen);
    public void QuitButtonClicked() => SceneManager.LoadScene(Utils.SCENE_MAIN_MENU);
}
