using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JoinRoomScreen : Screen
{
    [SerializeField] private Screen lobbyScreen;
    [SerializeField] private DynamicList roomList;
    private void OnEnable()
    {
        PhotonManager.Instance.OnRoomListUpdateAction += UpdateRoomList;
    }
    private void OnDisable()
    {
        PhotonManager.Instance.OnRoomListUpdateAction -= UpdateRoomList;
    }

    private void Awake()
    {
        if (lobbyScreen == null)
            Utils.DebugNullReference("JoinRoomScreen", "lobbyScreen");
        if (roomList == null)
            Utils.DebugNullReference("JoinRoomScreen", "roomList");
    }

    private void UpdateRoomList()
    {
        if (!roomList.isActiveAndEnabled)
            return;
        roomList.UpdateData(PhotonManager.Instance.roomList);
    }

    public override void Enable()
    {
        base.Enable();
        UpdateRoomList();
    }

    public void BackButtonClicked() => ScreenTransition(lobbyScreen);
}
