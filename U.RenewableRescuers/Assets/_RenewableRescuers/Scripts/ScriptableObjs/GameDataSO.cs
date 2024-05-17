using System;
using UnityEngine;

[CreateAssetMenu]
public class GameDataSO : ScriptableObject
{
    public bool bIsMobileDevice = false;
    public bool bMobileUIEnabled = false;
    public float time = 0f;

    public Action OnMusicChanged = null;
    private float _music = 1f;
    public float music
    {
        get { return _music; }
        set {
            _music = value;
            if (OnMusicChanged != null)
                OnMusicChanged();
        }
    }

    public Action OnSoundFXChanged = null;
    private float _soundfx = 1f;
    public float soundfx
    {
        get { return _soundfx; }
        set {
            _soundfx = value;
            if (OnSoundFXChanged != null)
                OnSoundFXChanged();
        }
    }
}
