using UnityEngine;

public class Utils
{
    public const string SCENE_MAIN_MENU = "MainMenu";
    public const string SCENE_RENEWABLE_ENERGY = "RenewableEnergy";
    public const string SCENE_NET_ZERO = "NetZero";
    public const string SCENE_INFILL = "Infill";
    public const string INPUT_AXIS_VERTICAL = "Vertical";
    public const string INPUT_AXIS_HORIZONTAL = "Horizontal";
    public const string INPUT_BUTTON_JUMP = "Jump";

    public static float easeOutCubic(float t)
    {
        return 1 - Mathf.Pow(1 - t, 3);
    }
}
