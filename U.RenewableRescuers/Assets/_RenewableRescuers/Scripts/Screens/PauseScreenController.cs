using UnityEngine;
using System;

public class PauseScreenController : MonoBehaviour
{
    [SerializeField] private Screen pauseScreen;
    [SerializeField] private Screen settingsScreen;
    public bool bIsEnabled = false;

    private void Start()
    {
        if (pauseScreen == null)
            throw new NullReferenceException();
         if (settingsScreen == null)
            throw new NullReferenceException();
    }

    private void Update()
    {
        // resume game on escape pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (bIsEnabled)
            {
                pauseScreen.Disable();
                settingsScreen.Disable();
                Utils.UnfreezeTime();
            }
            else
            {
                pauseScreen.Enable();
                Utils.FreezeTime();
            }
            bIsEnabled = !bIsEnabled;
        }
    }

    public void PauseButtonClicked()
    {
        Utils.FreezeTime();
        bIsEnabled = true;
        pauseScreen.Enable();
    }
}
