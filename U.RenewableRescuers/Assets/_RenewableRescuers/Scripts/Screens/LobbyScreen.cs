using UnityEngine;

public class LobbyScreen : Screen
{
    [SerializeField] private GameDataSO gameData;
    [SerializeField] private Screen startScreen;
    [SerializeField] private Screen createRoomScreen;
    [SerializeField] private Screen joinRoomScreen;

    void OnEnable()
    {
        PhotonManager.Instance.OnJoinedLobbyAction += JoinedLobbyAction;
    }

    void OnDisable()
    {
        PhotonManager.Instance.OnJoinedLobbyAction -= JoinedLobbyAction;
    }

    void Awake()
    {
        if (gameData == null)
            Utils.DebugNullReference("LobbyScreen", "gameData");
        if (startScreen == null)
            Utils.DebugNullReference("LobbyScreen", "startScreen");
        if (createRoomScreen == null)
            Utils.DebugNullReference("LobbyScreen", "createRoomScreen");
        if (joinRoomScreen == null)
            Utils.DebugNullReference("LobbyScreen", "joinRoomScreen");
    }

    private void JoinedLobbyAction()
    {
        if (!gameData.bReturnToJoinRoomScreen)
            Enable();
    }

    public void CreateGameButtonClicked()
    {
        createRoomScreen.Enable();
        Disable();
    }

    public void JoinGameButtonClicked()
    {
        joinRoomScreen.Enable();
        Disable();
    }

    public void BackButtonClicked()
    {
        PhotonManager.Instance.Disconnect();
        ScreenTransition(startScreen);
    }
}
