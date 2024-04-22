using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SauceTable : Base
{
    [SerializeField] private ObjekDapurSO objekDapurSO;

    public override void interact(TouchExample touchExample)
    {
        if (!HasObjekDapur())
        {
            if (!touchExample.HasObjekDapur())
            {
                Transform ObjectTransform = Instantiate(objekDapurSO.prefab);

                ObjectTransform.GetComponent<ObjekDapur>().SetObjekDapurParent(touchExample);
            }
            Debug.Log("hey2");
        }
        else
        {
            if (touchExample.HasObjekDapur())
            {
                Debug.Log("hey1");
                if (touchExample.GetObjekDapur().TryGetPlate(out PlateObjekDapur plateObjekDapur))
                {
                    //PlateObjekDapur plateObjekDapur = touchExample.GetObjekDapur() as PlateObjekDapur;
                    if (plateObjekDapur.TryaddIngredient(GetObjekDapur().GetObjekDapurSO()))
                    {
                        Debug.Log("Hey");
                        GetObjekDapur().DestroySelf();
                    }
                }


            }

        }
        


    }
}
