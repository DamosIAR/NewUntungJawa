using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCabinet : Base
{
    [SerializeField] private ObjekDapurSO objekDapurSO;

    public override void interact(TouchExample touchExample)
    {
        if (!touchExample.HasObjekDapur())
        {
            Transform ObjectTransform = Instantiate(objekDapurSO.prefab);

            ObjectTransform.GetComponent<ObjekDapur>().SetObjekDapurParent(touchExample);
        }


    }
}
