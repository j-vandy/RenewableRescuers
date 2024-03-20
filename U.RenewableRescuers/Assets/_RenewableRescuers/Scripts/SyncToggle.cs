using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class SyncToggle : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    [SerializeField] private PhotonView photonView;

    private void Awake()
    {
        if (toggle == null)
            Utils.DebugNullReference("SyncToggle", "toggle");
    }

    public void OnValueChanged(bool value)
    {
        if (PhotonNetwork.IsConnected)
            photonView.RPC("SyncToggleState", RpcTarget.All, value);
    }

}
