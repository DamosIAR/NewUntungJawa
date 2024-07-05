using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButtonHandler : MonoBehaviour
{
    [SerializeField] private GameObject ShopPanel;
    void Start()
    {
        ShopPanel.SetActive(false);
    }

    public void OpenShopButton()
    {
        ShopPanel.SetActive(true);
    }

    public void CloseShopButton()
    {
        ShopPanel.SetActive(false);
    }
}
