using System;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class SolarPanel : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite solar;
    public bool isLocked = true;
    [ShowIf("isLocked")]
    [SerializeField] private Sprite question;
    [ShowIf("isLocked")]
    [SerializeField] private GameObject questionnare;
    [SerializeField] private List<Powerable> connections = new List<Powerable>();
    [SerializeField] private SoundFX_Manager soundFXManager;
    [SerializeField] private ParticleSystem particle;
    private Vector3 init_pos;

    void Start()
    {
        init_pos = transform.parent.position;
        if (isLocked && question == null)
            throw new NullReferenceException();
        if (connections.Count <= 0)
            Debug.LogWarning("Solar panel has no connections");

        // set sprite
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
            throw new NullReferenceException();
        if (isLocked)
            spriteRenderer.sprite = question;
        else
            spriteRenderer.sprite = solar;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isLocked && collision.tag == "Player")
        {
            questionnare.SetActive(true);
            Utils.FreezeTime();
        }
    }

    public void Unlock()
    {
        isLocked = false;
        spriteRenderer.sprite = solar;
    }

    public void PowerOn()
    {
        if (isLocked)
            return;
        foreach (var connection in connections)
            connection.PowerOn();
    }

    public void PowerOff()
    {
        if (isLocked)
            return;
        foreach (var connection in connections)
            connection.PowerOn();
    }

    public void Return()
    {
        particle.Play();
        soundFXManager.PlayExplosion();
        transform.parent.position = init_pos;
    }
}
