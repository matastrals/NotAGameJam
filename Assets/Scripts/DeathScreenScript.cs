using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class DeathScreenScript : MonoBehaviour
{
    public GameObject deadScreen;
    public TMP_Text deadText;
    public TMP_Text hintText;
    private Animator deadScreenAnimator;
    private Animator deadTextAnimator;

    private void Start()
    {
        deadScreenAnimator = deadScreen.GetComponent<Animator>();
        deadTextAnimator = deadText.GetComponent<Animator>();
        deadScreen.gameObject.SetActive(false);
        deadText.gameObject.SetActive(false);
        hintText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)) { StartCoroutine(DeathAnimation()); }
    }

    public void callDeathScreen()
    {
        StartCoroutine(DeathAnimation());
    }


    IEnumerator DeathAnimation()
    {
        deadScreen.gameObject.SetActive(true);
        deadScreenAnimator.Play("DeathScreen"); ;
        yield return new WaitUntil(() => AnimationFinished(deadScreenAnimator));
        deadText.gameObject.SetActive(true);
        deadTextAnimator.Play("DeathText");
        yield return new WaitUntil( () => AnimationFinished(deadTextAnimator));
        hintText.gameObject.SetActive(true);
        yield return new WaitUntil(() => UnityEngine.InputSystem.Keyboard.current.eKey.wasPressedThisFrame);
        deadScreen.gameObject.SetActive(false);
        deadText.gameObject.SetActive(false);
        hintText.gameObject.SetActive(false);
    }


    private bool AnimationFinished(Animator animator)
    {
        return animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1;
    }
}
