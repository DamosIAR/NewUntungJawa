using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeliveryManager : MonoBehaviour
{
    public static DeliveryManager Instance { get; private set; }
    [SerializeField] private ResepListSO resepListSO;
    [SerializeField] private TextMeshProUGUI Money;

    private List<ResepSO> WaitingresepSOList;
    private float spawnRecipeTimer;
    private float spawnRecipeTimerMax = 4f;
    private int waitingResepMax = 4;
    private int money;

    private void Awake()
    {
        Instance = this;
        WaitingresepSOList = new List<ResepSO>();
    }

    private void Update()
    {
        spawnRecipeTimer -= Time.deltaTime;
        if(spawnRecipeTimer <= 0 )
        {
            spawnRecipeTimer = spawnRecipeTimerMax;

            if(WaitingresepSOList.Count < waitingResepMax)
            {
                ResepSO waitingResepSO = resepListSO.resepSOList[Random.Range(0, resepListSO.resepSOList.Count)];
                Debug.Log(waitingResepSO.namaResep);
                WaitingresepSOList.Add(waitingResepSO);
            }
        }
    }

    public void DeliverRecipe(PlateObjekDapur plateObjekDapur)
    {
        for(int  i = 0; i < WaitingresepSOList.Count; i++)
        {
            ResepSO waitingRecipeSO = WaitingresepSOList[i];

            if(waitingRecipeSO.objekDapurSOlist.Count == plateObjekDapur.GetObjekDapurSOList().Count)
            {
                bool plateContentMatchesRecipe = true;
                foreach(ObjekDapurSO recipeObjekDapurSO in waitingRecipeSO.objekDapurSOlist)
                {
                    bool ingredientFound = false;
                    foreach(ObjekDapurSO plateObjekDapurSO in plateObjekDapur.GetObjekDapurSOList())
                    {
                        if(plateObjekDapurSO == recipeObjekDapurSO)
                        {
                            ingredientFound = true;
                            break;
                        }
                    }
                    if(!ingredientFound)
                    {
                        plateContentMatchesRecipe = false;
                    }
                }
                if (plateContentMatchesRecipe)
                {
                    Debug.Log("Masakan Benar");
                    WaitingresepSOList.RemoveAt(i);
                    AddMoney();
                    return;
                }
            }
        }
        Debug.Log("Resep yang dimasukkan salah");
    }

    private void AddMoney()
    {
        money += 10;
        Money.text = "" + money;
    }
}
