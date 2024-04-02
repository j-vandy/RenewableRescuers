using ExitGames.Client.Photon;
using UnityEngine;
using UnityEngine.UI;

public class WaitingRoomScreen : Screen
{
    [SerializeField] private GameDataSO gameData;
    [SerializeField] private Screen loadingScreen;
    [SerializeField] private Toggle toggle;
    [SerializeField] private Button startButton;

    private void OnEnable()
    {
        PhotonManager.Instance.OnJoinedRoomAction += Enable;
        PhotonManager.Instance.OnPlayerEnteredRoomAction += PlayerEnteredRoomAction;
        PhotonManager.Instance.OnPlayerLeftRoomAction += DisableStartButton;
        PhotonManager.Instance.OnCloseRoomEventAction += CloseRoomEvent;
        PhotonManager.Instance.OnEventAction += UpdatePlayerValue;
    }

    private void OnDisable()
    {
        PhotonManager.Instance.OnJoinedRoomAction -= Enable;
        PhotonManager.Instance.OnPlayerEnteredRoomAction -= PlayerEnteredRoomAction;
        PhotonManager.Instance.OnPlayerLeftRoomAction -= DisableStartButton;
        PhotonManager.Instance.OnCloseRoomEventAction -= CloseRoomEvent;
        PhotonManager.Instance.OnEventAction += UpdatePlayerValue;
    }

    private void Awake()
    {
        if (gameData == null)
            Utils.DebugNullReference("WaitingRoomScreen", "gameData");
        if (loadingScreen == null)
            Utils.DebugNullReference("WaitingRoomScreen", "loadingScreen");
        if (toggle == null)
            Utils.DebugNullReference("WaitingRoomScreen", "toggle");
        if (startButton == null)
            Utils.DebugNullReference("WaitingRoomScreen", "startButton");
    }

    private void CloseRoomEvent()
    {
        if (!gameData.bIsHost)
        {
            ScreenTransition(loadingScreen);
            gameData.bIsHost = false;
            gameData.bIsEddy = false;
        }    
    }

    private void PlayerEnteredRoomAction()
    {
        if (gameData.bIsHost)
            OnToggleValueChanged();
        startButton.interactable = true;
    }

    private void DisableStartButton()
    {
        startButton.interactable = false;
    }

    public override void Enable()
    {
        foreach (Transform child in transform)
        {
            if (child.GetComponent<Button>() == startButton && !gameData.bIsHost)
                continue;
            if (child.GetComponent<Toggle>() == toggle && !gameData.bIsHost)
                continue;
            child.gameObject.SetActive(true);
        }
        if (gameData.bIsHost)
            toggle.isOn = true;
    }

    public void OnToggleValueChanged()
    {
        object eventContent = toggle.isOn;
        PhotonManager.Instance.RaiseEventAll(PhotonManager.EVENT_CODE_EDDY_TOGGLE, eventContent);
    }

    public void UpdatePlayerValue(EventData eventData)
    {
        if (eventData.Code != PhotonManager.EVENT_CODE_EDDY_TOGGLE)
            return;
        
        bool toggleValue = (bool)eventData.CustomData;
        if (gameData.bIsHost)
            gameData.bIsEddy = toggleValue;
        else
            gameData.bIsEddy = !toggleValue;
    }

    public void StartButtonClicked()
    {
        PhotonManager.Instance.LoadLevel(Utils.SCENE_RENEWABLE_ENERGY);
    }

    public void BackButtonClicked()
    {
        ScreenTransition(loadingScreen);

        if (gameData.bIsHost)
            PhotonManager.Instance.CloseRoom();
        else
            PhotonManager.Instance.LeaveRoom();

        gameData.bIsHost = false;
        gameData.bIsEddy = false;
    }
}
