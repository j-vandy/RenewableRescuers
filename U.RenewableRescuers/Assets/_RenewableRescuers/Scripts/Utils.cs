using UnityEngine;

public class Utils
{
    public const string SCENE_MAIN_MENU = "MainMenu";
    public const string SCENE_RENEWABLE_ENERGY = "RenewableEnergy";
    public const string INPUT_AXIS_VERTICAL = "Vertical";
    public const string INPUT_AXIS_HORIZONTAL = "Horizontal";
    public const string INPUT_BUTTON_JUMP = "Jump";
    public const string LAYER_PLAYER = "Player";

    public static float easeOutCubic(float t)
    {
        return 1 - Mathf.Pow(1 - t, 3);
    }
}
