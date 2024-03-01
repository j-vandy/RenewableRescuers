using UnityEngine;

public class StartScreen : Screen
{
    [SerializeField] private Screen lobbyScreen;

    void OnEnable()
    {
        PhotonManager.Instance.OnJoinedLobbyAction += LoadLobbyScreen;
    }

    void OnDisable()
    {
        PhotonManager.Instance.OnJoinedLobbyAction -= LoadLobbyScreen;
    }

    void Awake()
    {
        if (lobbyScreen == null)
            Utils.DebugNullReference("StartScreen", "lobbyScreen");
    }

    private void LoadLobbyScreen()
    {
        lobbyScreen.Enable();
        Disable();
    }

    public void StartBttnClicked()
    {
        PhotonManager.Instance.ConnectUsingSettings();
    }
}
