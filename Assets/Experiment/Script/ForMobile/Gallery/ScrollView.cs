using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollView : MonoBehaviour
{
    [SerializeField] private GameObject CreditsContent;
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
            isActive = true;
        }
        else
        {
            CreditsContent.gameObject.SetActive(false);
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
