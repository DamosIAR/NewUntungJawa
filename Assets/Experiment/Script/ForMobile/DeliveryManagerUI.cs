using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManagerUI : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private Transform recipeTemplate;

    private void Start()
    {
        DeliveryManager.Instance.onRecipeSpawned += DeliveryManager_onRecipeSpawned;
        DeliveryManager.Instance.onRecipeCompleted += DeliveryManager_onRecipeCompleted;

        Updatevisual();
    }

    private void DeliveryManager_onRecipeCompleted(object sender, System.EventArgs e)
    {
        Updatevisual();
    }

    private void DeliveryManager_onRecipeSpawned(object sender, System.EventArgs e)
    {
        Updatevisual();
    }

    private void Awake()
    {
        recipeTemplate.gameObject.SetActive(false);
    }

    private void Updatevisual()
    {
        foreach (Transform child in container)
        {
            if (child == recipeTemplate) continue;
            Destroy(child.gameObject);
        }

        foreach(ResepSO resepSO in DeliveryManager.Instance.GetWaitingRecipeSOList())
        {
            Transform recipeTransform = Instantiate(recipeTemplate, container);
            recipeTransform.gameObject.SetActive(true);
            recipeTransform.GetComponent<DeliveryManagerSingleUI>().SetRecipeSO(resepSO);
        }
    }
}
