using UnityEngine;
using Photon.Pun;
using System;
using Photon.Realtime;
using System.Collections.Generic;
using ExitGames.Client.Photon;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    private const bool DEBUG_ENABLED = true;
    private const byte CLOSE_ROOM_EVENT_CODE = 13;
    private bool bHasLeftRoom = false;
    public const int MAX_PLAYERS = 2;
    public Action OnConnectToMasterAction = null;
    public Action OnJoinedLobbyAction = null;
    public Action OnCreateRoomAction = null;
    public Action OnJoinedRoomAction = null;
    public Action OnCloseRoomEventAction = null;
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
                PhotonNetwork.EnableCloseConnection = true;
                PhotonNetwork.AutomaticallySyncScene = true;
                GameObject obj = new GameObject("PhotonManager");
                _Instance = obj.AddComponent<PhotonManager>();
            }
            return _Instance;
        }
    }


    public override void OnEnable()
    {
        base.OnEnable();
        PhotonNetwork.NetworkingClient.EventReceived += OnCloseRoomEvent;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        PhotonNetwork.NetworkingClient.EventReceived -= OnCloseRoomEvent;
    }

    private void OnCloseRoomEvent(EventData photonEvent)
    {
        byte eventCode = photonEvent.Code;
        if (eventCode == CLOSE_ROOM_EVENT_CODE)
        {
            if (OnCloseRoomEventAction != null)
                OnCloseRoomEventAction();
            PhotonNetwork.LeaveRoom();
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
        base.OnConnectedToMaster();
        if (OnConnectToMasterAction != null)
            OnConnectToMasterAction();
        PhotonNetwork.JoinLobby();
        if (DEBUG_ENABLED)
            Debug.Log("Connected to Photon servers");
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        if (OnJoinedLobbyAction != null)
            OnJoinedLobbyAction();
        if (DEBUG_ENABLED)
            Debug.Log("Joined lobby");
    }

    public void CreateRoom(string roomName)
    {
        PhotonNetwork.CreateRoom(roomName, new RoomOptions { MaxPlayers = MAX_PLAYERS });
    }

    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        if (OnCreateRoomAction != null)
            OnCreateRoomAction();
        if (DEBUG_ENABLED)
            Debug.Log("Room created successfully");
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        if (OnJoinedRoomAction != null)
            OnJoinedRoomAction();
        if (DEBUG_ENABLED)
            Debug.Log("Joined room: " + PhotonNetwork.CurrentRoom.Name);
    }

    public void CloseRoom()
    {
        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.CurrentRoom.IsVisible = false;
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.Others };
        PhotonNetwork.RaiseEvent(CLOSE_ROOM_EVENT_CODE, null, raiseEventOptions, SendOptions.SendReliable);
        PhotonNetwork.LeaveRoom();
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        if (OnLeftRoomAction != null)
            OnLeftRoomAction();

        bHasLeftRoom = true;

        if (DEBUG_ENABLED)
            Debug.Log("Left room successfully");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        if (OnPlayerEnteredRoomAction != null)
            OnPlayerEnteredRoomAction();
        if (DEBUG_ENABLED)
            Debug.Log("Player entered room");
    }

    public override void OnPlayerLeftRoom(Player newPlayer)
    {
        base.OnPlayerLeftRoom(newPlayer);
        if (OnPlayerLeftRoomAction != null)
            OnPlayerLeftRoomAction();
        if (DEBUG_ENABLED)
            Debug.Log("Player left room");
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
        base.OnRoomListUpdate(roomList);
        this.roomList = roomList;
        if (OnRoomListUpdateAction != null)
            OnRoomListUpdateAction();

        // refresh room list by rejoining lobby to avoid
        // setting room list to the previous room you left
        if (bHasLeftRoom)
        {
            Debug.Log("HAS LEFT ROOM ACTIONS");
            Disconnect();
            ConnectUsingSettings();
            bHasLeftRoom = false;
        }

        if (DEBUG_ENABLED)
        {
            Debug.Log("Room List updated");
            Debug.Log("Size: " + roomList.Count);
            if (roomList.Count < 1)
                return;
            Debug.Log("Rooms:");
            foreach(var room in roomList)
            {
                Debug.Log("      " + room.Name);
            }
        }
    }
}
