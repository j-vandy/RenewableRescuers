using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameSelectionScreen : Screen
{
    [SerializeField] private Screen startScreen;

    void Awake()
    {
        if (startScreen == null)
            throw new NullReferenceException();
    }

    public void RenewableEnergyButtonClicked() => SceneManager.LoadScene(Utils.SCENE_RENEWABLE_ENERGY);

    public void NewZeroButtonClicked() => SceneManager.LoadScene(Utils.SCENE_NET_ZERO);

    public void InfillDevButtonClicked() => SceneManager.LoadScene(Utils.SCENE_INFILL);

    public void BackButtonClicked() => ScreenTransition(startScreen);
}
