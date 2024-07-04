using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatPositionHandler : MonoBehaviour
{
    public static BoatPositionHandler Instance { get; private set; }
    private float ZPosition;
    /*private float tickInterval;
    private float maxInterval = 3f;*/

    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        ZPosition = transform.position.z;
        /*tickInterval += Time.deltaTime;
        if (tickInterval >= maxInterval)
        {
            tickInterval = 0;
            Debug.Log(ZPosition);
        }*/
    }

    public float GetBoatPosition()
    {
        return ZPosition;
    }
}
