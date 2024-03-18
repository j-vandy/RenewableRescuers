using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class WaitingRoomScreen : Screen
{
    [SerializeField] private GameDataSO gameData;
    [SerializeField] private Screen lobbyScreen;
    [SerializeField] private Screen joinRoomScreen;
    [SerializeField] private Toggle toggle;
    [SerializeField] private Button startButton;

    private void OnEnable()
    {
        PhotonManager.Instance.OnPlayerEnteredRoomAction += EnableStartButton;
        PhotonManager.Instance.OnPlayerLeftRoomAction += DisableStartButton;
        PhotonManager.Instance.OnLeftRoomAction += OnLeftRoomLoadScreen;
    }

    private void OnDisable()
    {
        PhotonManager.Instance.OnPlayerEnteredRoomAction -= EnableStartButton;
        PhotonManager.Instance.OnPlayerLeftRoomAction -= DisableStartButton;
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
        if (toggle == null)
            Utils.DebugNullReference("WaitingRoomScreen", "toggle");
        if (startButton == null)
            Utils.DebugNullReference("WaitingRoomScreen", "startButton");
    }

    private void EnableStartButton()
    {
        startButton.interactable = true;
    }

    private void DisableStartButton()
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
        PhotonManager.Instance.LoadLevel(Utils.SCENE_RENEWABLE_ENERGY);
    }

    public void BackButtonClicked()
    {
        if (gameData.bIsHost)
            PhotonManager.Instance.CloseRoom();
        else
            PhotonManager.Instance.LeaveRoom();
    }

    public override void Enable()
    {
        foreach (Transform child in transform)
        {
            if (child.GetComponent<Button>() == startButton && !gameData.bIsHost)
                continue;
            if (child.GetComponent<Toggle>() == toggle && !gameData.bIsHost)
                continue;
            child.gameObject.SetActive(true);
        }
        SetPlayerCharacter(toggle.isOn);
    }

    public override void Disable()
    {
        if (gameData.bIsHost)
            toggle.isOn = true;
        base.Disable();
    }

    public void SetPlayerCharacter(bool IsEcoEddy)
    {
        gameData.Print();
        if (gameData.bIsHost)
            gameData.bIsEddy = IsEcoEddy;
        else
            gameData.bIsEddy = !IsEcoEddy;
        gameData.Print();
    }
}
