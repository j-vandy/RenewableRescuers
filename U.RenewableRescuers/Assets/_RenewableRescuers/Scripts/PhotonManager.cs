using UnityEngine;
using Photon.Pun;
using System;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    public Action OnConnectToMasterAction = null;
    public Action OnJoinedLobbyAction = null;
    public Action OnJoinedRoomAction = null;
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

    public void LoadLevel(string levelName)
    {
        PhotonNetwork.LoadLevel(levelName);
    }

    public void Instantiate(string prefabName, Vector3 position, Quaternion rotation)
    {
        PhotonNetwork.Instantiate(prefabName, position, rotation);
    }
}
