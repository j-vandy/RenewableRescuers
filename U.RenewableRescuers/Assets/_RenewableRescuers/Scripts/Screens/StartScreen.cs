using UnityEngine;

public class StartScreen : Screen
{
    [SerializeField] private Screen loadingScreen;
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
        if (loadingScreen == null)
            Utils.DebugNullReference("StartScreen", "loadingScreen");
        if (lobbyScreen == null)
            Utils.DebugNullReference("StartScreen", "lobbyScreen");
    }

    private void LoadLobbyScreen()
    {
        lobbyScreen.Enable();
        loadingScreen.Disable();
    }

    public void StartButtonClicked()
    {
        loadingScreen.Enable();
        Disable();
        PhotonManager.Instance.ConnectUsingSettings();
    }

    public void QuitButtonClicked()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
