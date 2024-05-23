using System;
using UnityEngine;

public class Utils
{
    public const string TAG_RENEWABLE_TARGET = "RenewableTarget";
    public const string TAG_SOLAR = "Solar";
    public const string TAG_REFLECT = "Reflect";

    public const string SCENE_MAIN_MENU = "MainMenu";

    public const string INPUT_AXIS_VERTICAL = "Vertical";
    public const string INPUT_AXIS_HORIZONTAL = "Horizontal";
    public const string INPUT_BUTTON_JUMP = "Jump";
    
    public const string ANIMATION_PLAYER_IDLE = "Player_Idle";
    public const string ANIMATION_PLAYER_PUSH = "Player_Push";
    public const string ANIMATION_PLAYER_WALK = "Player_Walk";
    public const string ANIMATION_PLAYER_JUMP = "Player_Jump";
    public const string ANIMATION_PLAYER_FALLING = "Player_Falling";
    public const string ANIMATION_PLAYER_LAND = "Player_Land";

    public const string ANIMATION_LEVER_LOCKED = "Locked";
    public const string ANIMATION_LEVER_UNLOCKED = "Unlocked";
    public const string ANIMATION_LEVER_QUESTION_OPEN = "QuestionOpen";
    public const string ANIMATION_LEVER_QUESTION_CLOSE = "QuestionClose";
    public const string ANIMATION_LEVER_TOGGLE_ON = "ToggleOn";
    public const string ANIMATION_LEVER_TOGGLE_OFF = "ToggleOff";

    public const string ANIMATION_DOOR_CLOSED = "Door_Closed";
    public const string ANIMATION_DOOR_ON_CLOSE = "Door_OnClose";
    public const string ANIMATION_DOOR_ON_OPEN = "Door_OnOpen";

    public const string ANIMATION_SWITCH_OFF = "Off";
    public const string ANIMATION_SWITCH_TURN_ON = "TurnOn";

    public static float easeOutCubic(float t)
    {
        return 1 - Mathf.Pow(1 - t, 3);
    }

    public static float easeOutBack(float t)
    {
        const float c1 = 1.70158f;
        const float c3 = c1 + 1;
        return (float) (1 + c3 * Math.Pow(t - 1, 3) + c1 * Math.Pow(t - 1, 2));
    }

    public static void FreezeTime()
    {
        Time.timeScale = 0;
    }

    public static void UnfreezeTime()
    {
        Time.timeScale = 1;
    }
}
