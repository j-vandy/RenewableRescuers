using Photon.Realtime;
using System;
using UnityEngine;
using TMPro;

public class ContentElement : MonoBehaviour
{
    [SerializeField] private TMP_Text playerCountText;
    [SerializeField] private TMP_Text roomNameText;
    [SerializeField] private JoinRoomScreen joinRoomScreen;
    private RoomInfo roomInfo;

    private void Awake()
    {
        
        if (playerCountText == null)
            throw new NullReferenceException();
        if (roomNameText == null)
            throw new NullReferenceException();
    }

    public void Set(RoomInfo roomInfo)
    {
        this.roomInfo = roomInfo;
        playerCountText.text = roomInfo.PlayerCount + "/" + PhotonManager.MAX_PLAYERS;
        roomNameText.text = roomInfo.Name;
        joinRoomScreen = transform.parent.parent.parent.GetComponent<JoinRoomScreen>();
        if (joinRoomScreen == null)
            throw new NullReferenceException();
    }

    public void OnJoinButtonPressed()
    {
        joinRoomScreen.TransitionToLoadingScreen();
        PhotonManager.Instance.JoinRoom(roomInfo.Name);
    }
}
