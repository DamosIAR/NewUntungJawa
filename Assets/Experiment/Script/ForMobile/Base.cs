using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour, IObjekDapurParent
{
    [SerializeField] private Transform TopBoxPrefab;

    private ObjekDapur objekDapur;

    public virtual void interact(TouchExample touchExample) {
        Debug.LogError("base.counter();");
    }

    public Transform GetObjekDapurFollowTransform()
    {
        return TopBoxPrefab;
    }

    public void SetObjekDapur(ObjekDapur objekDapur)
    {
        this.objekDapur = objekDapur;
    }

    public ObjekDapur GetObjekDapur()
    {
        return objekDapur;
    }

    public void ClearObjekDapur()
    {
        objekDapur = null;
    }

    public bool HasObjekDapur()
    {
        return objekDapur != null;
    }
}
