using UnityEngine;
using System;

public class ResetGameData : MonoBehaviour
{
    [SerializeField] private GameDataSO gameData;
    private void Start()
    {
        if (gameData == null)
            throw new NullReferenceException();
       gameData.ResetValues(); 
    }
}
