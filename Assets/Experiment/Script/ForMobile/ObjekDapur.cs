using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjekDapur : MonoBehaviour
{
    [SerializeField] private ObjekDapurSO objekDapurSO;

    public ObjekDapurSO GetObjekDapurSO() 
    {
        return objekDapurSO; 
    }
}
