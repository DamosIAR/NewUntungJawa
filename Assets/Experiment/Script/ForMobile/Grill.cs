using Mono.Cecil.Cil;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Grill : Base
{
    public event EventHandler<OnStateChangedEventArgs> OnStateChanged;
    public class OnStateChangedEventArgs : EventArgs
    {
        public State state;
    }

    public event EventHandler<OnProgressChangedEventArgs> OnProgressChanged;
    public class OnProgressChangedEventArgs : EventArgs { public float progressNormalized; }

    public enum State{
        Idle, 
        Grilling,
        Grilled,
        Burned,
    }

    [SerializeField] private GrillRecipeSO[] grillRecipeSOArray;
    [SerializeField] private BurningRecipeSO[] burningRecipeSOArray;

    private State state;
    private float grillTimer;
    private GrillRecipeSO grillRecipeSO;
    private BurningRecipeSO burningRecipeSO;
    private float burningTimer;

    private void Start()
    {
        state = State.Idle;
    }

    private void Update()
    {
        if (HasObjekDapur())
        {
            switch (state)
            {
                case State.Idle:
                    break;
                case State.Grilling:
                    grillTimer += Time.deltaTime;
                    if (grillTimer > grillRecipeSO.grillTimerMax)
                    {
                        GetObjekDapur().DestroySelf();
                        ObjekDapur.SpawnObjekDapur(grillRecipeSO.output, this);
                        //Debug.Log("Matang");
                        state = State.Grilled;
                        burningTimer = 0f;
                        burningRecipeSO = GetBurningRecipeSOWithInput(GetObjekDapur().GetObjekDapurSO());
                        Debug.Log(grillTimer);
                        //grillTimer = 0f;

                        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs {
                            state = state
                        });
                    }
                    OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs
                    {
                        progressNormalized = grillTimer / grillRecipeSO.grillTimerMax
                    });
                    break;
                case State.Grilled:
                    burningTimer += Time.deltaTime;
                    if (burningTimer > burningRecipeSO.burningTimerMax)
                    {
                        GetObjekDapur().DestroySelf();
                        ObjekDapur.SpawnObjekDapur(burningRecipeSO.output, this);
                        Debug.Log("Gosong");
                        state = State.Grilling;
                        grillTimer = 0f;

                        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                        {
                            state = state
                        });
                        state = State.Burned;
                    }
                    OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs
                    {
                        progressNormalized = burningTimer / burningRecipeSO.burningTimerMax
                    });
                    break;
                case State.Burned:
                    break;
            }
            Debug.Log(state);
        }
    }



    public override void interact(TouchExample touchExample)
    {
        if (!HasObjekDapur())
        {
            if (touchExample.HasObjekDapur())
            {
                if (HasRecipeWithInput(touchExample.GetObjekDapur().GetObjekDapurSO()))
                {
                    touchExample.GetObjekDapur().SetObjekDapurParent(this);
                    grillRecipeSO = GetGrillRecipeSOWithInput(GetObjekDapur().GetObjekDapurSO());

                    state = State.Grilling;
                    grillTimer = 0;

                }
            }
            else
            {

            }
        }
        else
        {
            if(touchExample.HasObjekDapur())
            {

            }
            else
            {
                GetObjekDapur().SetObjekDapurParent(touchExample);
                state = State.Idle;

                OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                {
                    state = state,
                });
            }
        }
    }


    private bool HasRecipeWithInput(ObjekDapurSO inputObjekDapurSO)
    {
        GrillRecipeSO grillRecipeSO =  GetGrillRecipeSOWithInput(inputObjekDapurSO);
        return grillRecipeSO != null;
    }

    private ObjekDapurSO GetOutputForInput(ObjekDapurSO inputObjekDapurSO)
    {
        GrillRecipeSO grillRecipeSO = GetGrillRecipeSOWithInput(inputObjekDapurSO);
        if(grillRecipeSO != null)
        {
            return grillRecipeSO.output;
        }
        else
        {
            return null;
        }
    }

    private GrillRecipeSO GetGrillRecipeSOWithInput(ObjekDapurSO inputObjekDapurSO)
    {
        foreach(GrillRecipeSO grillRecipeSO in grillRecipeSOArray)
        {
            if(grillRecipeSO.input == inputObjekDapurSO)
            {
                return grillRecipeSO;
            }
        }
        return null;
    }

    private BurningRecipeSO GetBurningRecipeSOWithInput(ObjekDapurSO inputObjekDapurSO)
    {
        foreach (BurningRecipeSO burningRecipeSO in burningRecipeSOArray)
        {
            if (burningRecipeSO.input == inputObjekDapurSO)
            {
                return burningRecipeSO;
            }
        }
        return null;
    }
}
