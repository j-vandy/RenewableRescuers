using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DynamicList : MonoBehaviour
{
    [SerializeField] private GameObject contentElementPrefab;
    [SerializeField] private Transform content;
    private void Awake()
    {
        if (contentElementPrefab == null)
            throw new NullReferenceException();
        if (content == null)
            throw new NullReferenceException();
    }

    private void ClearList()
    {
        for (int i = 0; i < content.childCount; i++)
            Destroy(content.GetChild(i).gameObject);
    }

    public void UpdateData(List<RoomInfo> roomInfos)
    {
        ClearList();
        foreach(RoomInfo roomInfo in roomInfos)
        {
            if (roomInfo.PlayerCount <= 0 || roomInfo.PlayerCount >= PhotonManager.MAX_PLAYERS)
                continue;
            GameObject contentElement = Instantiate(contentElementPrefab);
            contentElement.transform.SetParent(content, false);
            contentElement.GetComponent<ContentElement>().Set(roomInfo);
        }
    }
}
