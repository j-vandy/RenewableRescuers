using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WaitingRoomScreen : Screen
{
    [SerializeField] private GameDataSO gameData;
    [SerializeField] private Screen lobbyScreen;
    [SerializeField] private Screen joinRoomScreen;
    [SerializeField] private Button startButton;

    private void OnEnable()
    {
        PhotonManager.Instance.OnPlayerEnteredRoomAction += EnableButton;
        PhotonManager.Instance.OnPlayerLeftRoomAction += DisableButton;
        PhotonManager.Instance.OnLeftRoomAction += OnLeftRoomLoadScreen;
    }

    private void OnDisable()
    {
        PhotonManager.Instance.OnPlayerEnteredRoomAction -= EnableButton;
        PhotonManager.Instance.OnPlayerLeftRoomAction -= DisableButton;
        PhotonManager.Instance.OnLeftRoomAction -= OnLeftRoomLoadScreen;
    }

    private void Awake()
    {
        if (gameData == null)
            Utils.DebugNullReference("WaitingRoomScreen", "gameData");
        if (lobbyScreen == null)
            Utils.DebugNullReference("WaitingRoomScreen", "lobbyScreen");
        if (joinRoomScreen == null)
            Utils.DebugNullReference("WaitingRoomScreen", "joinRoomScreen");
        if (startButton == null)
            Utils.DebugNullReference("WaitingRoomScreen", "startButton");
    }

    private void EnableButton()
    {
        startButton.interactable = true;
    }

    private void DisableButton()
    {
        startButton.interactable = false;
    }

    private void OnLeftRoomLoadScreen()
    {
        if (gameData.bIsHost)
            lobbyScreen.Enable();
        else
            joinRoomScreen.Enable();
        Disable();
    }

    public void StartButtonClicked()
    {
        PhotonManager.Instance.LoadLevel(Utils.SCENE_GAME);
    }

    public void BackButtonClicked()
    {
        if (gameData.bIsHost)
            PhotonManager.Instance.DestroyRoom();
        else
            PhotonManager.Instance.LeaveRoom();
    }
}
