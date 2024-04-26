using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeliveryManagerSingleUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI RecipeName;

    public void SetRecipeSO(ResepSO resepSO)
    {
        RecipeName.text = resepSO.namaResep;
    }
}
