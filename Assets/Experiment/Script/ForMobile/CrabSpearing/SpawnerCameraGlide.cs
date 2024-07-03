using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCameraGlide : MonoBehaviour
{
    public float moveSpeed;

    void Update()
    {
        if (!SpearGameManager.Instance.isGamePlaying()) return;
        Vector3 moveDirection = new Vector3(0,0,0);
        moveDirection.z = 1f;
        //float moveSpeed = 1f;

        transform.position += moveDirection * moveSpeed * Time.deltaTime;


    }
}
