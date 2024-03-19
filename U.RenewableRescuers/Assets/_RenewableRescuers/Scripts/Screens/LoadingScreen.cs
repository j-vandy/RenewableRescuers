public class LoadingScreen : Screen
{
    void OnEnable()
    {
        PhotonManager.Instance.OnJoinedLobbyAction += Disable;
        PhotonManager.Instance.OnJoinedRoomAction += Disable;
    }

    void OnDisable()
    {
        PhotonManager.Instance.OnJoinedLobbyAction -= Disable;
        PhotonManager.Instance.OnJoinedRoomAction -= Disable;
    }
}