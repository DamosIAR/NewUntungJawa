using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WATERSpawner : MonoBehaviour
{
    [SerializeField] private GameObject WATER;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("WaterTrigger"))
        {
            Instantiate(WATER, new Vector3(0, 0, BoatPositionHandler.Instance.GetBoatPosition() + 135), Quaternion.identity);
        }
    }
}
