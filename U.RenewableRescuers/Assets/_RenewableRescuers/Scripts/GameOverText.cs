using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameOverText : MonoBehaviour
{
    public TMP_Text text;
    public SoundFX_Manager soundFXManager;
    public GameDataSO gamedata;

    void Start()
    {
        text.text = "Score: " + ((int)gamedata.time).ToString().PadLeft(4, '0') + "\nCongratulations! You have finished the game!";
        soundFXManager.PlayWinner();
    }

    public void OnBackPressed()
    {
        gamedata.time = 0f;
        SceneManager.LoadScene(Utils.SCENE_MAIN_MENU);
    }
}
