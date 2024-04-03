using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjekDapurParent
{

    public Transform GetObjekDapurFollowTransform();


    public void SetObjekDapur(ObjekDapur objekDapur);


    public ObjekDapur GetObjekDapur();


    public void ClearObjekDapur();


    public bool HasObjekDapur();
    
}
