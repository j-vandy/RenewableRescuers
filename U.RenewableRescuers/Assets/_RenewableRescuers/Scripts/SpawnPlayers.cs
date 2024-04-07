using Photon.Pun;
using System.Collections;
using UnityEngine;
using System;

public class SpawnPlayers : MonoBehaviour
{
    private const float SPAWN_DELAY_DURATION = 0.25f;
    [SerializeField] private GameDataSO gameData;
    [SerializeField] private GameObject ecoEddyPrefab;
    [SerializeField] private GameObject solarSamPrefab;

    private void OnEnable()
    {
        if (gameData == null)
            throw new NullReferenceException();
        if (ecoEddyPrefab == null)
            throw new NullReferenceException();
        if (solarSamPrefab == null)
            throw new NullReferenceException();

        StartCoroutine(InstantiatePlayer());
    }
    
    private IEnumerator InstantiatePlayer()
    {
        yield return new WaitForSeconds(SPAWN_DELAY_DURATION);
        if (PhotonNetwork.IsConnected)
        {
            if (gameData.bIsEddy)
                PhotonManager.Instance.Instantiate(ecoEddyPrefab.name, new Vector3(-5f, 0f), Quaternion.identity);
            else
                PhotonManager.Instance.Instantiate(solarSamPrefab.name, new Vector3(5f, 0f), Quaternion.identity);
        }
    }
}
