using UnityEngine;

public class SettingsScreen : Screen
{
    [SerializeField] private Screen startScreen;
    private void Awake()
    {
        if (startScreen == null)
            Utils.DebugNullReference("SettingsScreen", "startScreen");
    }

    public void BackButtonClicked() => ScreenTransition(startScreen);
}
