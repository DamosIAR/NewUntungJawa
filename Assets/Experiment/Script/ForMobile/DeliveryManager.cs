using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DeliveryManager : MonoBehaviour
{
    public event EventHandler onRecipeSpawned;
    public event EventHandler onRecipeCompleted;
    public event EventHandler onRecipeFailed;
    public event EventHandler onRecipeSuccess;

    public static DeliveryManager Instance { get; private set; }
    [SerializeField] private ResepListSO resepListSO;
    [SerializeField] private TextMeshProUGUI Money;
    [SerializeField] private TextMeshProUGUI Money2;

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
        if (!CookGameManager.Instance.isGamePlaying()) return;
        spawnRecipeTimer -= Time.deltaTime;
        if(spawnRecipeTimer <= 0 )
        {
            spawnRecipeTimer = spawnRecipeTimerMax;

            if(WaitingresepSOList.Count < waitingResepMax)
            {
                ResepSO waitingResepSO = resepListSO.resepSOList[UnityEngine.Random.Range(0, resepListSO.resepSOList.Count)];
                WaitingresepSOList.Add(waitingResepSO);

                onRecipeSpawned?.Invoke(this, EventArgs.Empty);
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
                    WaitingresepSOList.RemoveAt(i);
                    onRecipeCompleted?.Invoke(this, EventArgs.Empty);
                    onRecipeSuccess?.Invoke(this, EventArgs.Empty);
                    AddMoney();
                    return;
                }
            }
        }

        onRecipeFailed?.Invoke(this, EventArgs.Empty);
    }

    private void AddMoney()
    {
        money += 10;
        Money.text = "" + money;
        Money2.text = "" + money;

    }

    public List<ResepSO> GetWaitingRecipeSOList()
    {
        return WaitingresepSOList;
    }
}
