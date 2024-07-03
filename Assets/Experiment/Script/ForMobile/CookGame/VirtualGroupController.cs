using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualGroupController : MonoBehaviour
{
    [SerializeField] private float positionx;

    public void ChangeStoreToFishStore()
    {
        Vector3 currentPosition = transform.position;
        float newXPosition = currentPosition.x;
        Vector3 newPosition = new Vector3(positionx, currentPosition.y, currentPosition.z);
        transform.position = newPosition;
    }

    public void ChangeStoreToPrawnStore()
    {
        Vector3 currentPosition = transform.position;
        float newXPosition = currentPosition.x;
        Vector3 newPosition = new Vector3(0, currentPosition.y, currentPosition.z);
        transform.position = newPosition;
    }


}
