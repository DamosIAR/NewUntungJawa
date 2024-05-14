using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    void Update()
    {
        if (CookGameManager.Instance.isCountdownToStartActive())
        {
            animator.SetTrigger("GameStart");
        }
        else if(CookGameManager.Instance.isGameOver())
        {
            animator.SetTrigger("GameOver");
        }
    }
}
