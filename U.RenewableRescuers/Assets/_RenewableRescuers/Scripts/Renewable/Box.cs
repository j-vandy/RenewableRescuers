using System;
using UnityEngine;

public class Box : MonoBehaviour
{
    private Vector3 init_pos;
    [SerializeField] private SoundFX_Manager soundFXManager;
    [SerializeField] private ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        if (soundFXManager == null)
            throw new NullReferenceException();
        init_pos = transform.position;
    }

    public void Return()
    {
        particle.Play();
        soundFXManager.PlayExplosion();
        transform.position = init_pos;
    }
}
