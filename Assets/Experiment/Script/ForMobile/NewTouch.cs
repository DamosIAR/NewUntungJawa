using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TouchExample : MonoBehaviour, IObjekDapurParent
{
    [SerializeField] Camera mainCamera;
    [SerializeField] private Transform ObjekDapurHoldPoint;

    private Base dasar;
    private ObjekDapur objekDapur;
    private VirtualCameraControl cameraControl; 

    //public static TouchExample Instance {  get; private set; }

    private void Start()
    {
        //Instance = this;
        cameraControl = GameObject.FindGameObjectWithTag("VirtualCameraTarget").GetComponent<VirtualCameraControl>();
        dasar = GameObject.FindGameObjectWithTag("Box").GetComponent<Box>();
    }

    void Update()
    {

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if (!CookGameManager.Instance.isGamePlaying()) return;
                if (hit.collider.tag == "ToBack")
                {
                    cameraControl.BackSideStore();
                }
                else if(hit.collider.tag == "ToFront")
                {
                    cameraControl.FrontSideStore();
                }

                if (hit.transform.TryGetComponent(out dasar))
                {
                    dasar.interact(this);
                }
               
            }
        }
    }

    public Transform GetObjekDapurFollowTransform()
    {
        return ObjekDapurHoldPoint;
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