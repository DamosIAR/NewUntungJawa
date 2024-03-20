using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("IsTrigger", false);
    }

    private void Update()
    {
        //startButton();
    }

    public void startButton()
    {
        Debug.Log("Start");
        animator.SetBool("IsTrigger", true);
        StartCoroutine(TriggerAfterWait(0.5f));
    }

    IEnumerator TriggerAfterWait(float delayinseconds)
    {
        yield return new WaitForSeconds(delayinseconds);
        animator.SetBool("IsTrigger", false);

    }


}
