using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class WaitingRoomScreen : Screen
{
    [SerializeField] private GameDataSO gameData;
    [SerializeField] private Screen loadingScreen;
    [SerializeField] private Toggle toggle;
    [SerializeField] private Button startButton;

    private void OnEnable()
    {
        PhotonManager.Instance.OnJoinedRoomAction += Enable;
        PhotonManager.Instance.OnPlayerEnteredRoomAction += EnableStartButton;
        PhotonManager.Instance.OnPlayerLeftRoomAction += DisableStartButton;
    }

    private void OnDisable()
    {
        PhotonManager.Instance.OnJoinedRoomAction -= Enable;

        PhotonManager.Instance.OnPlayerEnteredRoomAction -= EnableStartButton;
        PhotonManager.Instance.OnPlayerLeftRoomAction -= DisableStartButton;
    }

    private void Awake()
    {
        if (gameData == null)
            Utils.DebugNullReference("WaitingRoomScreen", "gameData");
        if (loadingScreen == null)
            Utils.DebugNullReference("WaitingRoomScreen", "loadingScreen");
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
        if (gameData.bIsHost)
            toggle.isOn = true;
        else
            SetPlayerCharacter(toggle.isOn);
    }

    public void SetPlayerCharacter(bool IsEcoEddy)
    {
        //Debug.LogError("NOT IMPLEMENTED CORRECTLY");
        return;

        if (gameData.bIsHost)
            gameData.bIsEddy = IsEcoEddy;
        else
            gameData.bIsEddy = !IsEcoEddy;
        gameData.Print();
    }

    public void StartButtonClicked()
    {
        PhotonManager.Instance.LoadLevel(Utils.SCENE_RENEWABLE_ENERGY);
    }

    public void BackButtonClicked()
    {
        ScreenTransition(loadingScreen);

        if (gameData.bIsHost)
            PhotonManager.Instance.CloseRoom();
        else
            PhotonManager.Instance.LeaveRoom();

        gameData.bIsHost = false;
        gameData.bIsEddy = false;
    }
}
