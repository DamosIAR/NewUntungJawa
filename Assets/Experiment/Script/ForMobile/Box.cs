using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private ObjekDapurSO objekDapurSO;
    [SerializeField] private Transform TopBoxPrefab;

    private ObjekDapur objekDapur;
    
    public void interact()
    {
        if(objekDapur == null)
        {
            Debug.Log("interact");
            Transform KitchenObjectTransform = Instantiate(objekDapurSO.prefab, TopBoxPrefab);
            KitchenObjectTransform.localPosition = Vector3.zero;

            objekDapur = KitchenObjectTransform.GetComponent<ObjekDapur>();

            Debug.Log(KitchenObjectTransform.GetComponent<ObjekDapur>().GetObjekDapurSO().objectName);
        }
        
    }
}
