using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PauseScreen : Screen
{
    [SerializeField] private PauseScreenController controller;
    [SerializeField] private Screen settingsScreen;
    [SerializeField] private GameDataSO gameData;

    void Awake()
    {
        if (controller == null)
            throw new NullReferenceException();
        if (settingsScreen == null)
            throw new NullReferenceException();
        if (gameData == null)
            throw new NullReferenceException();
    }

    public void ResumeButtonClicked()
    {
        controller.bIsEnabled = false;
        Utils.UnfreezeTime();
        Disable();
    }

    public void SettingsButtonClicked() => ScreenTransition(settingsScreen);
    public void QuitButtonClicked()
    {
        Utils.UnfreezeTime();
        gameData.time = 0f;
        SceneManager.LoadScene(Utils.SCENE_MAIN_MENU);
    }
}
