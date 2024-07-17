using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollView : MonoBehaviour
{
    [SerializeField] private GameObject CreditsContent;
    [SerializeField] private GameObject MasukButton;
    [SerializeField] private GameObject KeluarButton;
    private bool isActive;

    private void Start()
    {
        CreditsContent.gameObject.SetActive(false);
        isActive = false;
    }

    public void EnableDisableContent()
    {
        if (!isActive)
        {
            CreditsContent.gameObject.SetActive(true);
            MasukButton.gameObject.SetActive(false);
            KeluarButton.gameObject.SetActive(false);
            isActive = true;
        }
        else
        {
            CreditsContent.gameObject.SetActive(false);
            MasukButton.gameObject.SetActive(true);
            KeluarButton.gameObject.SetActive(true);
            isActive = false;
        }
        
    }

    public void DisableContent()
    {
        if (!isActive)
        {
            CreditsContent.gameObject.SetActive(false);
            isActive = false;
        }
        
    }
}
