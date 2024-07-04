using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WATERDespawner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boat"))
        {
            Destroy(gameObject);
        }
    }
}
