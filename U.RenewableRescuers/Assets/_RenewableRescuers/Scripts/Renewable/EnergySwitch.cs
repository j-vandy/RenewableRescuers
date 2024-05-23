using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnergySwitch : MonoBehaviour
{
    private Animator animator;
    private string currAnimationState;
    [SerializeField] private Sprite leaf;
    [SerializeField] private SpriteRenderer leaf_renderer;
    [SerializeField] ParticleSystem sys;
    [SerializeField] private GameObject progressBar;
    [SerializeField] private SoundFX_Manager sfx;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
            throw new NullReferenceException();
        if (leaf == null)
            throw new NullReferenceException();
        if (leaf_renderer == null)
            throw new NullReferenceException();
        if (sys == null)
            throw new NullReferenceException();
        if (progressBar == null)
            throw new NullReferenceException();
        if (sfx == null)
            throw new NullReferenceException();
        currAnimationState = Utils.ANIMATION_SWITCH_OFF;
    }

    private void ChangeAnimationState(string newAnimationState)
    {
        if (currAnimationState == newAnimationState)
            return;

        currAnimationState = newAnimationState;
        animator.Play(newAnimationState);
    }

    private IEnumerator StuffAfterAnimation()
    {
        float delay = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(delay);
        leaf_renderer.sprite = leaf;
        yield return new WaitForSeconds(1.5f);
        sys.Play();
        Destroy(progressBar);
        sfx.PlayExplosion();
        yield return new WaitForSeconds(2f);
        Water.bGameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PowerOn()
    {
        ChangeAnimationState(Utils.ANIMATION_SWITCH_TURN_ON);
        StartCoroutine(StuffAfterAnimation());
    }
}
