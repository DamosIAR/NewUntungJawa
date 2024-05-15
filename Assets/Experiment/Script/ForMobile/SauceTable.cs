using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SauceTable : Base
{
    [SerializeField] private ObjekDapurSO objekDapurSO;

    public static event EventHandler onSaucePickedUp;

    public override void interact(TouchExample touchExample)
    {
        if (!HasObjekDapur())
        {
            if (touchExample.HasObjekDapur())
            {
                Transform ObjectTransform = Instantiate(objekDapurSO.prefab);

                ObjectTransform.GetComponent<ObjekDapur>().SetObjekDapurParent(this);
            }
        }



        if (HasObjekDapur())
        {
            if (touchExample.HasObjekDapur())
            {
                if (touchExample.GetObjekDapur().TryGetPlate(out PlateObjekDapur plateObjekDapur))
                {
                    onSaucePickedUp?.Invoke(this, EventArgs.Empty);
                    //PlateObjekDapur plateObjekDapur = touchExample.GetObjekDapur() as PlateObjekDapur;
                    if (plateObjekDapur.TryaddIngredient(GetObjekDapur().GetObjekDapurSO()))
                    {
                        GetObjekDapur().DestroySelf();
                    }
                }


            }
        }
            

        
        


    }
}
