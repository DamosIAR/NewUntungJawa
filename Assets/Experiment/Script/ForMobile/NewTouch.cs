using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TouchExample : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] GameObject Fish;
    GameObject PickedFish;
    bool fishSpawned = false;
    [SerializeField] GameObject Prawn;
    GameObject PickedPrawn;
    bool prawnSpawned = false;
    [SerializeField] GameObject Squid;
    GameObject PickedSquid;
    bool squidSpawned = false;

    bool somethingPicked = false;
    GameObject Picked;
    void Update()
    {


        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
               if ((hit.collider.tag == "FishBox" && fishSpawned == false) && somethingPicked == false)
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
                }
            }



        }
    }
    
    public void Spawned(GameObject gameobject, Vector3 location, Quaternion quaternion)
    {
        location = new Vector3();
        Picked = Instantiate(gameObject, location, quaternion);

    }

}