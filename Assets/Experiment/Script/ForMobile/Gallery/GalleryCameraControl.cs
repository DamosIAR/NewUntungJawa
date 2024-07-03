using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryCameraControl : MonoBehaviour
{
    private float startingPoint = 2500f;
    private float stoppingPoint = 1904f;
    private float speed = 400f;
    [SerializeField] private Camera Gallerycamera;

    void Start()
    {
        Gallerycamera.transform.position = new Vector3 (startingPoint, 1035f, 187f);
    }

    // Update is called once per frame
    void Update()
    {

        if(startingPoint > stoppingPoint)
        {
            startingPoint -= (speed * Time.deltaTime);
            float currentXPosition = startingPoint;
            Gallerycamera.transform.position = new Vector3(currentXPosition, 1035f, 187f);
        }
    }
}
