using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DeliveryManagerSingleUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI RecipeName;
    [SerializeField] private Transform IconContainer;
    [SerializeField] private Transform IconTemplate;


    private void Awake()
    {
        IconTemplate.gameObject.SetActive(false);
    }

    public void SetRecipeSO(ResepSO resepSO)
    {
        RecipeName.text = resepSO.namaResep;

        foreach(Transform child in IconContainer)
        {
            if (child == IconTemplate) continue;
            Destroy(child.gameObject);
        }

        foreach(ObjekDapurSO objekDapurSO in resepSO.objekDapurSOlist)
        {
            Transform iconTransform = Instantiate(IconTemplate, IconContainer);
            iconTransform.gameObject.SetActive(true);
            iconTransform.GetComponent<Image>().sprite = objekDapurSO.sprite;
            Debug.Log("hey");
            Debug.Log(objekDapurSO);
        }
    }
}
