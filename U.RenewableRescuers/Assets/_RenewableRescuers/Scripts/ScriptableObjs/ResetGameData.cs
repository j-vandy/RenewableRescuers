using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGameData : MonoBehaviour
{
    [SerializeField] private GameDataSO gameData;
    private void Start()
    {
        if (gameData == null)
            Utils.DebugNullReference("ResetGameData", "gameData");
       gameData.ResetValues(); 
    }
}
