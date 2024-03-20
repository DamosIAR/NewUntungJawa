using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpearSpawner : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    public GameObject spear;
    public float spearLifetime;
    private float shootingInterval = 1;
    private float timer;
    private bool canThrow;


    private void Update()
    {
        //Vector3 mousePos = Input.mousePosition;


        /*Vector3 worldPositoin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = worldPositoin;
        Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));*/

        if (!canThrow)
        {
            timer += Time.deltaTime;
            if (timer > shootingInterval)
            {
                canThrow = true;
                timer = 0;
            }
        }


        if (Input.GetMouseButtonDown(0) && canThrow)
        {
            canThrow = false;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                GameObject targetHit = hitInfo.transform.gameObject;
                Vector3 hitPos = hitInfo.point;
                if (targetHit != null)
                {
                    hitPos = hitPos + Vector3.up * spear.transform.localScale.y * 4;
                    GameObject spawnedSpear = Instantiate(spear, hitPos, Quaternion.identity);
                    Destroy(spawnedSpear, spearLifetime);
                }

                //transform.position = hitInfo.point;
            }

        }
    }

}
