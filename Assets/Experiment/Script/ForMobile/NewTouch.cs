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

    private void Start()
    {
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

                if(hit.collider.tag == "ToBack")
                {
                    cameraControl.BackSideStore();
                }
                else if(hit.collider.tag == "ToFront")
                {
                    cameraControl.FrontSideStore();
                }
                /*else if(hit.collider.tag == "Trash")
                {
                    
                }*/

                if(hit.transform.TryGetComponent(out dasar))
                {
                    dasar.interact(this);
                }

               


               /*if ((hit.collider.tag == "FishBox" && fishSpawned == false) && somethingPicked == false)
                {

                    Vector3 fishSpawnedLocation = new Vector3(2.5f, 1f, -10f);
                    PickedFish = Instantiate(Fish, fishSpawnedLocation , Quaternion.identity);
                    Debug.Log("Fish spawn");
                    fishSpawned = true;
                    somethingPicked = true;
                    Picked = PickedFish;
                    Debug.Log(Picked.ToString());
                    
                }
                else if ((hit.collider.tag == "FishBox" && fishSpawned == true) && somethingPicked == true)
                {
                    Destroy(Picked);
                    fishSpawned = false;
                    Debug.Log("Fish despawn");
                    somethingPicked= false;
                }

               if ((hit.collider.tag == "ShrimpBox" && prawnSpawned == false) && somethingPicked == false)
                {
                    Vector3 PrawnSpawnedLocation = new Vector3(-2f, 1f, -10f);
                    PickedPrawn = Instantiate(Prawn, PrawnSpawnedLocation, Quaternion.identity);
                    prawnSpawned = true;
                    Debug.Log("Prawn Spawned");
                    somethingPicked = true;
                    Picked = PickedPrawn;
                    Debug.Log(Picked.ToString());
                }
               else if ((hit.collider.tag == "ShrimpBox" && prawnSpawned == true) && somethingPicked == true)
                {
                    Destroy(Picked);
                    prawnSpawned = false;
                    Debug.Log("Prawn despawn");
                    somethingPicked = false;
                }

               if ((hit.collider.tag == "SquidBox" && squidSpawned == false) && somethingPicked == false )
                {
                    Vector3 squidSpawnedLocation = new Vector3(6.5f, 1f, -10f);
                    PickedSquid = Instantiate(Squid, squidSpawnedLocation, Quaternion.identity);
                    squidSpawned = true;
                    Debug.Log("Squid Spawn");
                    somethingPicked = true;
                    Picked = PickedSquid; 
                    Debug.Log(Picked.ToString());
                }
               else if ((hit.collider.tag == "SquidBox" && squidSpawned == true) && somethingPicked == true)
                {
                    Destroy(Picked);
                    squidSpawned = false;
                    Debug.Log("Squid despawn");
                    somethingPicked = false;
                }


               if (hit.collider.tag == "Grill" && somethingPicked == true)
                {
                    Debug.Log("Grill");
                    Picked.transform.position = new Vector3(-6.3f, 0.7f, -11f);
                    somethingPicked = false;
                }*/
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