using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjekDapur : MonoBehaviour
{
    [SerializeField] private ObjekDapurSO objekDapurSO;

    private Box box;
    public ObjekDapurSO GetObjekDapurSO() 
    {
        return objekDapurSO; 
    }

    public void setEmptyBox(Box box)
    {
        if(this.box != null)
        {
            this.box.ClearObjekDapur();
        }

        this.box = box;

        /*if (box.HasObjekDapur())
        {
            Debug.LogError("Sudah ada isinya");
        }*/

        box.SetObjekDapur(this);

        transform.parent = box.GetObjekDapurFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    public Box getEmptyBox()
    {
        return box;
    }

}
