using Photon.Pun;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    private const float SPAWN_DELAY_DURATION = 0.25f;
    [SerializeField] private GameDataSO gameData;
    [SerializeField] private GameObject ecoEddyPrefab;
    [SerializeField] private GameObject solarSamPrefab;

    private void OnEnable()
    {
        if (gameData == null)
            Utils.DebugNullReference("SpawnPlayer", "gameData");
        if (ecoEddyPrefab == null)
            Utils.DebugNullReference("SpawnPlayer", "ecoEddyPrefab");
        if (solarSamPrefab == null)
            Utils.DebugNullReference("SpawnPlayer", "solarSamPrefab");

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
