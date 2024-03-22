using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualCameraControl : MonoBehaviour
{
    /*public float radius = 5f;
    public float speed = 2f;
    private float angle = 0f;*/

    public void BackSideStore()
    {
        Vector3 currentPosition = transform.position;
        float newZPosition = -currentPosition.z;
        Vector3 newPosition = new Vector3(currentPosition.x, currentPosition.y, newZPosition);
        transform.position = newPosition;
    }

    public void FrontSideStore()
    {
        Vector3 currentPosition = transform.position;
        float newZPosition = Mathf.Abs(currentPosition.z);
        Vector3 newPosition = new Vector3(currentPosition.x, currentPosition.y, newZPosition);
        transform.position = newPosition;
        
    }

    public void NextStore()
    {

    }

    public void PrevStore()
    {

    }
    
}
