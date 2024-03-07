using UnityEngine;
using Photon.Pun;
using System;
using Photon.Realtime;
using System.Collections.Generic;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    public Action OnConnectToMasterAction = null;
    public Action OnJoinedLobbyAction = null;
    public Action OnJoinedRoomAction = null;
    public Action OnLeftRoomAction = null;
    public Action OnRoomListUpdateAction = null;
    public Action OnPlayerEnteredRoomAction = null;
    public Action OnPlayerLeftRoomAction = null;
    public List<RoomInfo> roomList = new List<RoomInfo>();
    private static PhotonManager _Instance;
    public static PhotonManager Instance
    {
        get
        {
            if (_Instance == null)
            {
                GameObject obj = new GameObject("PhotonManager");
                _Instance = obj.AddComponent<PhotonManager>();
            }
            return _Instance;
        }
    }

    public void ConnectUsingSettings()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void Disconnect()
    {
        PhotonNetwork.Disconnect();
    }

    public override void OnConnectedToMaster()
    {
        if (OnConnectToMasterAction != null)
            OnConnectToMasterAction();
        PhotonNetwork.JoinLobby();
        base.OnConnectedToMaster();
    }

    public override void OnJoinedLobby()
    {
        if (OnJoinedLobbyAction != null)
            OnJoinedLobbyAction();
        base.OnJoinedLobby();
    }

    public void CreateRoom(string roomName)
    {
        PhotonNetwork.CreateRoom(roomName);
    }

    public void DestroyRoom()
    {
        foreach (Player player in PhotonNetwork.PlayerList)
            PhotonNetwork.CloseConnection(player);
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public override void OnJoinedRoom()
    {
        if (OnJoinedRoomAction != null)
            OnJoinedRoomAction();
        base.OnJoinedRoom();
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        if (OnLeftRoomAction != null)
            OnLeftRoomAction();
        base.OnLeftRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (OnPlayerEnteredRoomAction != null)
            OnPlayerEnteredRoomAction();
        base.OnPlayerEnteredRoom(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player newPlayer)
    {
        if (OnPlayerLeftRoomAction != null)
            OnPlayerLeftRoomAction();
        base.OnPlayerLeftRoom(newPlayer);
    }

    public void LoadLevel(string levelName)
    {
        PhotonNetwork.LoadLevel(levelName);
    }

    public void Instantiate(string prefabName, Vector3 position, Quaternion rotation)
    {
        PhotonNetwork.Instantiate(prefabName, position, rotation);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        this.roomList = roomList;

        if (OnRoomListUpdateAction != null)
            OnRoomListUpdateAction();

        base.OnRoomListUpdate(roomList);
    }
}
