using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCabinet : Base
{
    [SerializeField] private ObjekDapurSO objekDapurSO;

    public static PlateCabinet Instance { get; private set; }
    public static event EventHandler onPlatePickup;

    private void Awake()
    {
        Instance = this;
    }

    public override void interact(TouchExample touchExample)
    {
        if (!touchExample.HasObjekDapur())
        {
            onPlatePickup?.Invoke(this, EventArgs.Empty);
            Transform ObjectTransform = Instantiate(objekDapurSO.prefab);

            ObjectTransform.GetComponent<ObjekDapur>().SetObjekDapurParent(touchExample);
        }


    }
}
