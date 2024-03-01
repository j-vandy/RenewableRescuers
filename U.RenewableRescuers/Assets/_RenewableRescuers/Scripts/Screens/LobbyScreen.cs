using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyScreen : Screen
{
    [SerializeField] private TMP_InputField createInputField;
    [SerializeField] private TMP_InputField joinInputField;

    void OnEnable()
    {
        PhotonManager.Instance.OnJoinedRoomAction += LoadLevel;
    }

    void OnDisable()
    {
        PhotonManager.Instance.OnJoinedRoomAction -= LoadLevel;
    }

    void Awake()
    {
        if (createInputField == null)
            Utils.DebugNullReference("LobbyScreen", "createInputField");
        if (createInputField == null)
            Utils.DebugNullReference("LobbyScreen", "joinInputField");
    }

    private void LoadLevel()
    {
        PhotonManager.Instance.LoadLevel(Utils.SCENE_GAME);
    }

    public void CreateBttnClicked()
    {
        PhotonManager.Instance.CreateRoom(createInputField.text);
    }

    public void JoinBttnClicked()
    {
        PhotonManager.Instance.JoinRoom(joinInputField.text);
    }
}
