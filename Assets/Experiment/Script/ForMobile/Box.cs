using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private Transform objectPrefab;
    [SerializeField] private Transform TopBoxPrefab;
    public void interact()
    {
        Debug.Log("interact");
        Instantiate(objectPrefab, TopBoxPrefab);
        //objectTransform.localPosition = Vector3.zero;
    }
}
