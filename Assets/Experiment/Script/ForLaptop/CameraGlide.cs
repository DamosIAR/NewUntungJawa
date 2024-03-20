using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGlide : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = new Vector3(0,0,0);
        moveDirection.z = 1f;
        //float moveSpeed = 1f;

        transform.position += moveDirection * moveSpeed * Time.deltaTime;


    }
}
