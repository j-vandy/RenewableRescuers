using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;

    void Start()
    {
        if (playerPrefab == null)
        {
            Utils.DebugNullReference("SpawnPlayer", "playerPrefab");
            return;
        }

        Vector3 randomPosition = new Vector3(Random.value * 16f - 8f, Random.value * 8f - 4f);
        PhotonManager.Instance.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
    }
}
