using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualCameraControl : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void BackSideStore()
    {
        Vector3 currentPosition = transform.position;
        float newZPosition = -(currentPosition.z);
        Vector3 newPosition = new Vector3(currentPosition.x, currentPosition.y, -100f);
        transform.position = newPosition;
        audioSource.Play();
    }

    public void FrontSideStore()
    {
        Vector3 currentPosition = transform.position;
        float newZPosition = Mathf.Abs(currentPosition.z);
        Vector3 newPosition = new Vector3(currentPosition.x, currentPosition.y, 100f);
        transform.position = newPosition;
        audioSource.Play();
    }
    
}
