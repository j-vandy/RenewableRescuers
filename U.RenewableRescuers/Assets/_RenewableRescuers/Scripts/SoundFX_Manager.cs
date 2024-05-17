using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundFX_Manager : MonoBehaviour
{
    [SerializeField] private GameDataSO gameData;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource audioSource1;
    [SerializeField] private AudioSource audioSource2;
    [SerializeField] private AudioSource audioSource3;
    [SerializeField] private AudioClip correct;
    [SerializeField] private AudioClip explosion;
    [SerializeField] private AudioClip general;
    [SerializeField] private AudioClip player_jump;
    [SerializeField] private AudioClip ui;
    [SerializeField] private AudioClip winner;
    [SerializeField] private AudioClip wrong;
    private Queue<AudioSource> queue = new Queue<AudioSource>();

    private void OnEnable()
    {
        gameData.OnSoundFXChanged += OnSoundFXUpdated;
    }

    private void OnDisable()
    {
        gameData.OnSoundFXChanged -= OnSoundFXUpdated;
    }

    private void Awake()
    {
        if (gameData == null)
            throw new NullReferenceException();
        audioSource.volume = gameData.soundfx;
        audioSource1.volume = gameData.soundfx;
        audioSource2.volume = gameData.soundfx;
        audioSource3.volume = gameData.soundfx;
        queue.Enqueue(audioSource);
        queue.Enqueue(audioSource1);
        queue.Enqueue(audioSource2);
        queue.Enqueue(audioSource3);
    }

    private void OnSoundFXUpdated()
    {
        audioSource.volume = gameData.soundfx;
        audioSource1.volume = gameData.soundfx;
        audioSource2.volume = gameData.soundfx;
        audioSource3.volume = gameData.soundfx;
    }

    private void PlayClip(AudioClip clip)
    {
        AudioSource a = queue.Dequeue();
        a.clip = clip;
        a.Play();
        queue.Enqueue(a);
    }

    public void PlayCorrect() => PlayClip(correct);
    public void PlayExplosion() => PlayClip(explosion);
    public void PlayGeneral() => PlayClip(general);
    public void PlayPlayerJump() => PlayClip(player_jump);
    public void PlayUI() => PlayClip(ui);
    public void PlayWinner() => PlayClip(winner);
    public void PlayWrong() => PlayClip(wrong);
}
