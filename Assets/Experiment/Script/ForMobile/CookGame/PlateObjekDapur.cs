using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateObjekDapur : ObjekDapur
{
    public event EventHandler<OnIngredientAddedEventargs> OnIngredientAdded;
    public class OnIngredientAddedEventargs : EventArgs
    {
        public ObjekDapurSO objekDapurSO;
    }

    [SerializeField] private List<ObjekDapurSO> ValidObjekDapurSOList;

    private List<ObjekDapurSO> objekDapurSOList;

    public List<ObjekDapurSO> GetObjekDapurSOList()
    {
        return objekDapurSOList;
    }

    private void Awake()
    {
        objekDapurSOList = new List<ObjekDapurSO>();
    }

    public bool TryaddIngredient(ObjekDapurSO objekDapurSO)
    {
        if (!ValidObjekDapurSOList.Contains(objekDapurSO))
        {
            return false;
        }
        if(objekDapurSOList.Contains(objekDapurSO))
        {
            return false;
        }
        else
        {
            objekDapurSOList.Add(objekDapurSO);
            OnIngredientAdded?.Invoke(this, new OnIngredientAddedEventargs{
                objekDapurSO = objekDapurSO
            });
            return true;
        }
    }
}
