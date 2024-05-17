using UnityEngine;
using System;
using TMPro;

public class Volume : MonoBehaviour
{
    [SerializeField] private GameDataSO gameData;
    [SerializeField] private TMP_Text text;
    public bool bIsMusic = false;
    private int val = 10;

    void Start()
    {
        if (gameData == null)
            throw new NullReferenceException();

        int v = bIsMusic ? (int)(gameData.music * 10) : (int) (gameData.soundfx * 10);
        Mathf.Clamp(v, 0, 10);
        val = v;
        text.text = val.ToString();
    }

    public void Add()
    {
        if (val >= 10)
            return;
        val++;
        text.text = val.ToString();
        if (bIsMusic)
            gameData.music = val / 10f;
        else
            gameData.soundfx = val / 10f;
    }

    public void Sub()
    {
        if (val <= 0)
            return;
        val--;
        text.text = val.ToString();
        if (bIsMusic)
            gameData.music = val / 10f;
        else
            gameData.soundfx = val / 10f;
    }
}
