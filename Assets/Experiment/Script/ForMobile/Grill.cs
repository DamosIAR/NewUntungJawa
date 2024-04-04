using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grill : Base
{
    [SerializeField] private GrillRecipeSO[] grillRecipeSOArray;

    private float grillTimer;

    private void Update()
    {
        if (HasObjekDapur())
        {
            grillTimer += Time.deltaTime;
            GrillRecipeSO grillRecipeSO = GetGrillRecipeSOWithInput(GetObjekDapur().GetObjekDapurSO());
            if (grillTimer > grillRecipeSO.grillTimerMax)
            {
                grillTimer = 0;
                Debug.Log("Matang");
                GetObjekDapur().DestroySelf();
                ObjekDapur.SpawnObjekDapur(grillRecipeSO.output, this);
            }
            Debug.Log(grillTimer);
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
}
