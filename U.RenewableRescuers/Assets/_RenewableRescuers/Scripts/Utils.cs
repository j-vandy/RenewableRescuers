using System;
using System.Collections;
using UnityEngine;

public class Utils
{
    public const string TAG_RENEWABLE_TARGET = "RenewableTarget";

    public const string SCENE_MAIN_MENU = "MainMenu";
    public const string SCENE_RENEWABLE_ENERGY = "RenewableEnergy";

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

    public static float easeOutCubic(float t)
    {
        return 1 - Mathf.Pow(1 - t, 3);
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
