using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateRoomScreen : Screen
{
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
        if (waitingRoomScreen == null)
            Utils.DebugNullReference("CreateRoomScreen", "waitingRoomScreen");
        if (gameNameInputField == null)
            Utils.DebugNullReference("CreateRoomScreen", "gameNameInputField");
    }

    private void JoinWaitingRoom()
    {
        waitingRoomScreen.Enable();
        Disable();
    }

    public void CreateButtonClicked()
    {
        PhotonManager.Instance.CreateRoom(gameNameInputField.text);
    }
}
