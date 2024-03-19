using UnityEngine;

public class StartScreen : Screen
{
    [SerializeField] private Screen loadingScreen;
    [SerializeField] private Screen lobbyScreen;
    [SerializeField] private Screen settingsScreen;
    [SerializeField] private Screen creditsScreen;

    void Awake()
    {
        if (loadingScreen == null)
            Utils.DebugNullReference("StartScreen", "loadingScreen");
        if (lobbyScreen == null)
            Utils.DebugNullReference("StartScreen", "lobbyScreen");
        if (settingsScreen == null)
            Utils.DebugNullReference("StartScreen", "settingsScreen");
        if (creditsScreen == null)
            Utils.DebugNullReference("StartScreen", "creditsScreen");
    }

    public void StartButtonClicked()
    {
        ScreenTransition(loadingScreen);
        PhotonManager.Instance.ConnectUsingSettings();
    }

    public void SettingsButtonClicked() => ScreenTransition(settingsScreen);

    public void CreditsButtonClicked() => ScreenTransition(creditsScreen);

    public void QuitButtonClicked()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
