using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjekDapur : MonoBehaviour
{
    [SerializeField] private ObjekDapurSO objekDapurSO;

    private IObjekDapurParent objekDapurParent;
    public ObjekDapurSO GetObjekDapurSO() 
    {
        return objekDapurSO; 
    }

    public void SetObjekDapurParent(IObjekDapurParent objekDapurParent)
    {

        if (this.objekDapurParent != null)
        {
            this.objekDapurParent.ClearObjekDapur();
        }



        this.objekDapurParent = objekDapurParent;
        if (objekDapurParent.HasObjekDapur())
        {
            Debug.LogError("Udah ada");
            
        }


        objekDapurParent.SetObjekDapur(this);

        /*if(objekDapurParent != null)
        {
            objekDapurParent.ClearObjekDapur();
        }*/
        transform.parent = objekDapurParent.GetObjekDapurFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    public IObjekDapurParent GetObjekDapurParent()
    {
        return objekDapurParent;
    }

    public void DestroySelf()
    {
        objekDapurParent.ClearObjekDapur() ;
        Destroy(gameObject);
    }

    public bool TryGetPlate(out PlateObjekDapur plateObjekDapur)
    {
        if(this is PlateObjekDapur)
        {
            plateObjekDapur = this as PlateObjekDapur;
            return true;
        }
        else
        {
            plateObjekDapur = null;
            return false;
        }
    }

    public static ObjekDapur SpawnObjekDapur(ObjekDapurSO objekDapurSO, IObjekDapurParent objekDapurParent)
    {
        Transform objekDapurTrasnform = Instantiate(objekDapurSO.prefab);
        ObjekDapur objekDapur = objekDapurTrasnform.GetComponent<ObjekDapur>();
            
        objekDapur.SetObjekDapurParent(objekDapurParent);

        return objekDapur;
    }

}
