using TMPro;
using UnityEngine;
using System;

public class CreateRoomScreen : Screen
{
    [SerializeField] private GameDataSO gameData;
    [SerializeField] private Screen loadingScreen;
    [SerializeField] private Screen lobbyScreen;
    [SerializeField] private TMP_InputField gameNameInputField;

    void Awake()
    {
        if (gameData == null)
            throw new NullReferenceException();
        if (loadingScreen == null)
            throw new NullReferenceException();
        if (lobbyScreen == null)
            throw new NullReferenceException();
        if (gameNameInputField == null)
            throw new NullReferenceException();
    }

    public void CreateButtonClicked()
    {
        gameData.bIsHost = true;
        PhotonManager.Instance.CreateRoom(gameNameInputField.text);
        gameNameInputField.text = "";
        ScreenTransition(loadingScreen);
    }

    public void BackButtonClicked() => ScreenTransition(lobbyScreen);
}
