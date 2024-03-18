using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    [SerializeField] private GameDataSO gameData;
    [SerializeField] private GameObject ecoEddyPrefab;
    [SerializeField] private GameObject solarSamPrefab;
    private bool bPlayerSpawned = false;

    void Start()
    {
        if (gameData == null)
        {
            Utils.DebugNullReference("SpawnPlayer", "gameData");
            return;
        }
        if (ecoEddyPrefab == null)
        {
            Utils.DebugNullReference("SpawnPlayer", "ecoEddyPrefab");
            return;
        }
        if (solarSamPrefab == null)
        {
            Utils.DebugNullReference("SpawnPlayer", "solarSamPrefab");
            return;
        }

        if (!bPlayerSpawned)
        {
            if (gameData.bIsEddy)
                PhotonManager.Instance.Instantiate(ecoEddyPrefab.name, new Vector3(-5f, 0f), Quaternion.identity);
            else
                PhotonManager.Instance.Instantiate(solarSamPrefab.name, new Vector3(5f, 0f), Quaternion.identity);
            bPlayerSpawned = true;
        }
    }
}
