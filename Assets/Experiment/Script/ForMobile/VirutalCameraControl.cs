using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirutalCameraControl : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float maxRight = 88f;
    [SerializeField] private float maxLeft = 0f;
    
    public void StoreOnTheRight()
    {
        Vector3 ToRight = new Vector3(0, 0, 0);
        ToRight.x = ToRight.x + 44f;
        transform.position = ToRight;
        
    }

    public void StoreOnTheLeft()
    {
        Vector3 ToLeft = new Vector3(0,0,0);
        ToLeft.x = ToLeft.x - 44f;
        transform.position = ToLeft;
        
        
    }

    
}
