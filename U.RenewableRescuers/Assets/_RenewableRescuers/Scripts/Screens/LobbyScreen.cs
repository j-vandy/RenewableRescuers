using UnityEngine;
using System;

public class LobbyScreen : Screen
{
    [SerializeField] private GameDataSO gameData;
    [SerializeField] private Screen startScreen;
    [SerializeField] private Screen createRoomScreen;
    [SerializeField] private Screen joinRoomScreen;

    void OnEnable()
    {
        PhotonManager.Instance.OnJoinedLobbyAction += JoinedLobbyAction;
    }

    void OnDisable()
    {
        PhotonManager.Instance.OnJoinedLobbyAction -= JoinedLobbyAction;
    }

    void Awake()
    {
        if (gameData == null)
            throw new NullReferenceException();
        if (startScreen == null)
            throw new NullReferenceException();
        if (createRoomScreen == null)
            throw new NullReferenceException();
        if (joinRoomScreen == null)
            throw new NullReferenceException();
    }

    private void JoinedLobbyAction()
    {
        if (!gameData.bReturnToJoinRoomScreen)
            Enable();
    }

    public void CreateGameButtonClicked()
    {
        createRoomScreen.Enable();
        Disable();
    }

    public void JoinGameButtonClicked()
    {
        joinRoomScreen.Enable();
        Disable();
    }

    public void BackButtonClicked()
    {
        PhotonManager.Instance.Disconnect();
        ScreenTransition(startScreen);
    }
}
