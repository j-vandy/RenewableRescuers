using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyScreen : Screen
{
    [SerializeField] private Screen startScreen;
    [SerializeField] private Screen createRoomScreen;
    [SerializeField] private Screen joinRoomScreen;

    void Awake()
    {
        if (startScreen == null)
            Utils.DebugNullReference("LobbyScreen", "startScreen");
        if (createRoomScreen == null)
            Utils.DebugNullReference("LobbyScreen", "createRoomScreen");
        if (joinRoomScreen == null)
            Utils.DebugNullReference("LobbyScreen", "joinRoomScreen");
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
