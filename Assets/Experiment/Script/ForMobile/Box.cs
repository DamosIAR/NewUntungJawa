using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Base
{
    [SerializeField] private ObjekDapurSO objekDapurSO;
    //private ObjekDapur objekDapur;

    public static Box Instance { get; private set; }

    public static event EventHandler onIngredientPickup;

    private void Awake()
    {
        Instance = this;
    }
    public override void interact(TouchExample touchExample)
    {
        if(!touchExample.HasObjekDapur())
        {
            onIngredientPickup?.Invoke(this, EventArgs.Empty);
            //ObjekDapur.SpawnObjekDapur(objekDapurSO)
            Transform KitchenObjectTransform = Instantiate(objekDapurSO.prefab);

            KitchenObjectTransform.GetComponent<ObjekDapur>().SetObjekDapurParent(touchExample);


        }
    }
}
