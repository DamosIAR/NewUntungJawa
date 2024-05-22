using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBPlayerStateManager : MonoBehaviour
{
    public static BBPlayerStateManager Instance { get; private set; }
    public event EventHandler IsFalling;

    private float targetRotation = 110f;


    private enum State
    {
        Riding,
        Falling,
    }

    private State state;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        switch (state)
        {
            case State.Riding:
                if(RotationHandler.Instance.GetRotation().y > targetRotation)
                {

                    state = State.Falling;
                    IsFalling?.Invoke(this, new EventArgs());
                }

                break;
            case State.Falling:
                break;
        }
    }

    public bool getRidingState()
    {
        return state == State.Riding;
    }

}
