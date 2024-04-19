using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateObjekDapur : ObjekDapur
{
    [SerializeField] private List<ObjekDapurSO> ValidObjekDapurSOList;

    private List<ObjekDapurSO> objekDapurSOList;

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
            return true;
        }
    }
}
