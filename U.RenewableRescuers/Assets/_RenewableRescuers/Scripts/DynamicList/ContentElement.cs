using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;

public class ContentElement : MonoBehaviour
{
    [SerializeField] private TMP_Text playerCountText;
    [SerializeField] private TMP_Text roomNameText;
    private RoomInfo roomInfo;

    private void Awake()
    {
        if (playerCountText == null)
        {
            Utils.DebugNullReference("ContentElement", "playerCountText");
        }
        if (roomNameText == null)
        {
            Utils.DebugNullReference("ContentElement", "roomNameText");
        }
    }

    public void Set(RoomInfo roomInfo)
    {
        this.roomInfo = roomInfo;
        playerCountText.text = roomInfo.PlayerCount + "/" + PhotonManager.MAX_PLAYERS;
        roomNameText.text = roomInfo.Name;
    }

    public void OnJoinButtonPressed()
    {
        PhotonManager.Instance.JoinRoom(roomInfo.Name);
    }
}
