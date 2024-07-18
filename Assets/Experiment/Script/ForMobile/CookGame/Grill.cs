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
    [SerializeField] private GameObject PanasText;

    private State state;
    private float grillTimer;
    private GrillRecipeSO grillRecipeSO;
    private BurningRecipeSO burningRecipeSO;
    private float burningTimer;

    private void Start()
    {
        state = State.Idle;
        PanasText.gameObject.SetActive(false);
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
                        state = State.Grilled;
                        burningTimer = 0f;
                        burningRecipeSO = GetBurningRecipeSOWithInput(GetObjekDapur().GetObjekDapurSO());

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
                        grillTimer = 0f;
                        state = State.Burned;

                        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                        {
                            state = state
                        });
                    }
                    OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs
                    {
                        progressNormalized = burningTimer / burningRecipeSO.burningTimerMax
                    });
                    break;
                case State.Burned:
                    break;
            }
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
/*                    GetObjekDapur().transform.localEulerAngles = Vector3.zero;
*/
                    state = State.Grilling;
                    grillTimer = 0;
                    OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                    {
                        state = state
                    });

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
                if (touchExample.GetObjekDapur().TryGetPlate(out PlateObjekDapur plateObjekDapur))
                {
                    //PlateObjekDapur plateObjekDapur = touchExample.GetObjekDapur() as PlateObjekDapur;
                    if (plateObjekDapur.TryaddIngredient(GetObjekDapur().GetObjekDapurSO()))
                    {
                        GetObjekDapur().DestroySelf();
                        state = State.Idle;

                        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                        {
                            state = state,
                        });

                        OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs
                        {
                            progressNormalized = 0
                        });
                    }
                }
            }
            else
            {
                if(state == State.Burned)
                {
                    GetObjekDapur().SetObjekDapurParent(touchExample);
                    state = State.Idle;

                    OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                    {
                        state = state,
                    });

                    OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs
                    {
                        progressNormalized = 0
                    });
                }
                else
                {
                    Debug.Log("PANAS");
                    PanasText.gameObject.SetActive(true);
                    StartCoroutine(PanasPOPUP());
                }

            }
        }
    }

    IEnumerator PanasPOPUP()
    {
        yield return new WaitForSeconds(1f);
        PanasText.gameObject.SetActive(false);
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
