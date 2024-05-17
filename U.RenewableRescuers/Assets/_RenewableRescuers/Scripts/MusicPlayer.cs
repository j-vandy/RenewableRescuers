using UnityEngine;
using System;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer instance;
    private AudioSource _audioSource;
    [SerializeField] private GameDataSO gameData;

    private void OnEnable()
    {
        gameData.OnMusicChanged += UpdateMusicVolume;
    }

    private void OnDisable()
    {
        gameData.OnMusicChanged -= UpdateMusicVolume;
    }

    private void Awake()
    {
        if (gameData == null)
            throw new NullReferenceException();
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource != null)
            _audioSource.Play();
    }

    private void UpdateMusicVolume()
    {
        _audioSource.volume = gameData.music;
    }
}