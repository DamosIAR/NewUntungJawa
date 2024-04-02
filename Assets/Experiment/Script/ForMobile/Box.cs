using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private ObjekDapurSO objekDapurSO;
    [SerializeField] private Transform TopBoxPrefab;
    [SerializeField] private Box secondEmptyBox;
    [SerializeField] bool testing;

    private VirtualCameraControl cameraControl;

    private ObjekDapur objekDapur;

    private void Start()
    {
        cameraControl = GameObject.FindGameObjectWithTag("VirtualCameraTarget").GetComponent<VirtualCameraControl>();
    }

    private void Update()
    {
        /*if(testing && (Input.touchCount > 0))
        {
            if(objekDapur != null)
            {
                objekDapur.setEmptyBox(secondEmptyBox);
                Debug.Log(objekDapur.getEmptyBox());
            }
        }*/
    }

    public void interact()
    {
        if(objekDapur == null)
        {
            //Debug.Log("interact");
            Transform KitchenObjectTransform = Instantiate(objekDapurSO.prefab, TopBoxPrefab);
            KitchenObjectTransform.localPosition = Vector3.zero;

            objekDapur = KitchenObjectTransform.GetComponent<ObjekDapur>();
            objekDapur.setEmptyBox(this);

            //Debug.Log(KitchenObjectTransform.GetComponent<ObjekDapur>().GetObjekDapurSO().objectName);
        }
        else
        {
            objekDapur.setEmptyBox(secondEmptyBox);
            cameraControl.BackSideStore();
            Debug.Log(objekDapur.getEmptyBox());
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
