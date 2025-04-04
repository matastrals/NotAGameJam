using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class DeathScreenScript : MonoBehaviour
{
    public Animator deadScreenAnimator;
    public Animation deadTextAnimator;

    IEnumerator DeathAnimation()
    {
        deadScreenAnimator.Play(0);
        yield return new WaitUntil(() => AnimationFinished(deadScreenAnimator));
        deadTextAnimator.Play("DeathText");
        yield return new WaitUntil(() => UnityEngine.InputSystem.Keyboard.current.eKey.wasPressedThisFrame);
    }

    private bool AnimationFinished(Animator animator)
    {
        return animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1;
    }
}
