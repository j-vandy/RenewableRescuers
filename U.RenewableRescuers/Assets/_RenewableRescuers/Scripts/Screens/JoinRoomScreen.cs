using UnityEngine;
using System;

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
            throw new NullReferenceException();
        if (loadingScreen == null)
            throw new NullReferenceException();
        if (lobbyScreen == null)
            throw new NullReferenceException();
        if (roomList == null)
            throw new NullReferenceException();
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
