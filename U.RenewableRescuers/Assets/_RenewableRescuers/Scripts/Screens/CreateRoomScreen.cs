using TMPro;
using UnityEngine;

public class CreateRoomScreen : Screen
{
    [SerializeField] private GameDataSO gameData;
    [SerializeField] private Screen loadingScreen;
    [SerializeField] private Screen lobbyScreen;
    [SerializeField] private TMP_InputField gameNameInputField;

    void Awake()
    {
        if (gameData == null)
            Utils.DebugNullReference("CreateRoomScreen", "gameData");
        if (loadingScreen == null)
            Utils.DebugNullReference("CreateRoomScreen", "loadingScreen");
        if (lobbyScreen == null)
            Utils.DebugNullReference("CreateRoomScreen", "lobbyScreen");
        if (gameNameInputField == null)
            Utils.DebugNullReference("CreateRoomScreen", "gameNameInputField");
    }

    public void CreateButtonClicked()
    {
        gameData.bIsHost = true;
        PhotonManager.Instance.CreateRoom(gameNameInputField.text);
        gameNameInputField.text = "";
        ScreenTransition(loadingScreen);
    }

    public void BackButtonClicked() => ScreenTransition(lobbyScreen);
}
