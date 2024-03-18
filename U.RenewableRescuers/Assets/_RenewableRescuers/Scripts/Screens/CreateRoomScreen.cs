using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateRoomScreen : Screen
{
    [SerializeField] private GameDataSO gameData;
    [SerializeField] private Screen lobbyScreen;
    [SerializeField] private Screen waitingRoomScreen;
    [SerializeField] private Screen loadingScreen;
    [SerializeField] private TMP_InputField gameNameInputField;

    void OnEnable()
    {
        PhotonManager.Instance.OnJoinedRoomAction += JoinWaitingRoom;
    }

    void OnDisable()
    {
        PhotonManager.Instance.OnJoinedRoomAction -= JoinWaitingRoom;
    }

    void Awake()
    {
        if (gameData == null)
            Utils.DebugNullReference("CreateRoomScreen", "gameData");
        if (lobbyScreen == null)
            Utils.DebugNullReference("CreateRoomScreen", "lobbyScreen");
        if (waitingRoomScreen == null)
            Utils.DebugNullReference("CreateRoomScreen", "waitingRoomScreen");
        if (loadingScreen == null)
            Utils.DebugNullReference("CreateRoomScreen", "loadingScreen");
        if (gameNameInputField == null)
            Utils.DebugNullReference("CreateRoomScreen", "gameNameInputField");
    }

    private void JoinWaitingRoom() => loadingScreen.ScreenTransition(waitingRoomScreen);

    public void CreateButtonClicked()
    {
        gameData.bIsHost = true;
        PhotonManager.Instance.CreateRoom(gameNameInputField.text);
        gameNameInputField.text = "";
        ScreenTransition(loadingScreen);
    }

    public void BackButtonClicked() => ScreenTransition(lobbyScreen);
}
