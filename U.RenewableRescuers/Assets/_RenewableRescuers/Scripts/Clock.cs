using System;
using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] private GameDataSO gameData;
    private TMP_Text text;

    void Start()
    {
        text = GetComponent<TMP_Text>();
        if (text == null)
            throw new NullReferenceException();
        if (gameData == null)
            throw new NullReferenceException();
    }

    void Update()
    {
        gameData.time += Time.deltaTime;
        string str = ((int)gameData.time).ToString().PadLeft(4, '0');
        text.text = str;
    }
}
