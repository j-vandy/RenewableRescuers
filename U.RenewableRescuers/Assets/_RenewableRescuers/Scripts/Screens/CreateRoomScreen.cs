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
        if (gameNameInputField == null)
            Utils.DebugNullReference("CreateRoomScreen", "gameNameInputField");
    }

    private void JoinWaitingRoom()
    {
        gameData.bIsHost = true;
        waitingRoomScreen.Enable();
        Disable();
    }

    public void CreateButtonClicked()
    {
        PhotonManager.Instance.CreateRoom(gameNameInputField.text);
    }

    public void BackButtonClicked()
    {
        lobbyScreen.Enable();
        Disable();
    }
}
