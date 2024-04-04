using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Base
{
    [SerializeField] private ObjekDapurSO objekDapurSO;
    //private ObjekDapur objekDapur;
    public override void interact(TouchExample touchExample)
    {
        if(!touchExample.HasObjekDapur())
        {
            Transform KitchenObjectTransform = Instantiate(objekDapurSO.prefab);
            KitchenObjectTransform.GetComponent<ObjekDapur>().SetObjekDapurParent(touchExample);

            
        }
        /*else
        {
            objekDapur.SetObjekDapurParent(touchExample);
        }*/
    }
}
