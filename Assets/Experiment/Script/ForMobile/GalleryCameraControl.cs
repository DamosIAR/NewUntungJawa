using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryCameraControl : MonoBehaviour
{
    private float startingPoint = 2500f;
    private float stoppingPoint = 2121f;
    private float speed = 400f;
    [SerializeField] private Camera Gallerycamera;

    void Start()
    {
        Vector3 currentPosition  = transform.position;
        float YPosition = currentPosition.y;
        float ZPosition = currentPosition.z;
        Gallerycamera.transform.position = new Vector3 (startingPoint, 1210f, 137f);
    }

    // Update is called once per frame
    void Update()
    {

        if(startingPoint > stoppingPoint)
        {
            startingPoint -= speed * Time.deltaTime;
            float currentXPosition = startingPoint;
            Gallerycamera.transform.position = new Vector3(currentXPosition, 1210f, 137f);
            Debug.Log("hey");
        }
    }
}
