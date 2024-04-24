using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServeTable : Base
{
    public override void interact(TouchExample touchExample)
    {
        Debug.Log("Serve");
        if (touchExample.HasObjekDapur())
        {
            if(touchExample.GetObjekDapur().TryGetPlate(out PlateObjekDapur plateObjekDapur))
            {
                DeliveryManager.Instance.DeliverRecipe(plateObjekDapur);
                touchExample.GetObjekDapur().DestroySelf();
            }
        }
    }
}
