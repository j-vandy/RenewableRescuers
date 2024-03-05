using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingRoomScreen : Screen
{
    public void StartButtonClicked()
    {
        PhotonManager.Instance.LoadLevel(Utils.SCENE_GAME);
    }
}
