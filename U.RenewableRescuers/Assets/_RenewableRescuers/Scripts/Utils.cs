using UnityEngine;

public class Utils
{
    public const string SCENE_MAIN_MENU = "MainMenu";
    public const string SCENE_RENEWABLE_ENERGY = "RenewableEnergy";
    public const string INPUT_AXIS_VERTICAL = "Vertical";
    public const string INPUT_AXIS_HORIZONTAL = "Horizontal";

    public static void DebugNullReference(string script, string variable)
    {
        Debug.LogError("ERROR@" + script + ": reference to '" + variable + "' is null.");
    }
}
