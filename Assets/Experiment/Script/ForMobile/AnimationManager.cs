using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("IsTrigger", false);
        animator.SetBool("ExitTrigger", false);
    }

    public void startButton()
    {
        animator.SetBool("IsTrigger", true);
        StartCoroutine(TriggerAfterWait(0.5f));
    }

    IEnumerator TriggerAfterWait(float delayinseconds)
    {
        yield return new WaitForSeconds(delayinseconds);
        animator.SetBool("IsTrigger", false);
        animator.SetBool("ExitTrigger", false);
    }

    public void exitButton()
    {
        animator.SetBool("IsTrigger", true);
        StartCoroutine(TriggerAfterWait(0.5f));
    }


}
