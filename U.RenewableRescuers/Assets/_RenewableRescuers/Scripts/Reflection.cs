using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflection : MonoBehaviour
{
    private Vector3 init_pos;
    public bool isActive = false;
    public bool is45 = false;
    [SerializeField] private GameObject sprite45;
    [SerializeField] private GameObject ray;
    [SerializeField] private Sprite on;
    [SerializeField] private Sprite off;
    [SerializeField] private SoundFX_Manager soundFXManager;
    [SerializeField] private ParticleSystem particle;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        init_pos = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (isActive)
            PowerOn();
        else
            PowerOff();
    }
    public void PowerOn()
    {
        if (is45)
            sprite45.SetActive(true);
        spriteRenderer.sprite = on;
        ray.SetActive(true);
        isActive = true;
    }
    public void PowerOff()
    {
        if (is45)
            sprite45.SetActive(false);
        spriteRenderer.sprite = off;
        ray.GetComponent<Ray>().NoHit();
        ray.SetActive(false);
        isActive = false;
    }
    public void Return()
    {
        PowerOff();
        particle.Play();
        soundFXManager.PlayExplosion();
        transform.position = init_pos;
    }
}
