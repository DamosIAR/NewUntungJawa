using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IObjekDapurParent
{
    [SerializeField] private ObjekDapurSO objekDapurSO;
    [SerializeField] private Transform TopBoxPrefab;

    private VirtualCameraControl cameraControl;
    private ObjekDapur objekDapur;

    private void Start()
    {
        cameraControl = GameObject.FindGameObjectWithTag("VirtualCameraTarget").GetComponent<VirtualCameraControl>();
    }

    public void interact(TouchExample touchExample)
    {
        if(objekDapur == null)
        {
            Transform KitchenObjectTransform = Instantiate(objekDapurSO.prefab, TopBoxPrefab);
            KitchenObjectTransform.localPosition = Vector3.zero;

            objekDapur = KitchenObjectTransform.GetComponent<ObjekDapur>();
            objekDapur.SetObjekDapurParent(this);
        }
        else
        {
            objekDapur.SetObjekDapurParent(touchExample);
            Debug.Log(objekDapur.GetObjekDapurParent());
        }
        
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
