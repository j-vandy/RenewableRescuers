using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JoinRoomScreen : Screen
{
    [SerializeField] private GameDataSO gameData;
    [SerializeField] private Screen loadingScreen;
    [SerializeField] private Screen lobbyScreen;
    [SerializeField] private DynamicList roomList;

    private void OnEnable()
    {
        PhotonManager.Instance.OnJoinedLobbyAction += JoinedLobbyAction;
        PhotonManager.Instance.OnRoomListUpdateAction += UpdateRoomList;
    }
    private void OnDisable()
    {
        PhotonManager.Instance.OnJoinedLobbyAction -= JoinedLobbyAction;
        PhotonManager.Instance.OnRoomListUpdateAction -= UpdateRoomList;
    }

    private void Awake()
    {
        if (gameData == null)
            Utils.DebugNullReference("JoinRoomScreen", "gameData");
        if (loadingScreen == null)
            Utils.DebugNullReference("JoinRoomScreen", "loadingScreen");
        if (lobbyScreen == null)
            Utils.DebugNullReference("JoinRoomScreen", "lobbyScreen");
        if (roomList == null)
            Utils.DebugNullReference("JoinRoomScreen", "roomList");
    }

    private void JoinedLobbyAction()
    {
        if (gameData.bReturnToJoinRoomScreen)
            Enable();
    }

    private void UpdateRoomList()
    {
        roomList.UpdateData(PhotonManager.Instance.roomList);
    }

    public override void Enable()
    {
        gameData.bReturnToJoinRoomScreen = true;
        base.Enable();
        roomList.UpdateData(PhotonManager.Instance.roomList);
    }

    public void TransitionToLoadingScreen() => ScreenTransition(loadingScreen);

    public void BackButtonClicked()
    {
        gameData.bReturnToJoinRoomScreen = false;
        ScreenTransition(lobbyScreen);
    }
}
