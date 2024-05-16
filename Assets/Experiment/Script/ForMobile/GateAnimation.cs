using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    /*public static event EventHandler onGateMove;
    public static GateAnimation Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }*/

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
