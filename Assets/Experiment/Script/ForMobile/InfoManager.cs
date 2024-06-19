using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoManager : MonoBehaviour
{
    public static InfoManager instance;

    public GameObject InfoList;
    private bool isActive;

    private void Start()
    {
        instance = this;
        InfoList.gameObject.SetActive(false);
        isActive = false;
    }

    public void INFO(Image image)
    {
        if(!isActive)
        {
            image.gameObject.SetActive(true);
            isActive = true;
        }
        else
        {
            image.gameObject.SetActive(false);
            isActive = false;
        }
    }

    public void DisableInfoGameObject()
    {
        InfoList.gameObject.SetActive(false);
        isActive = false;
    }

    public void EnableInfoGameObject()
    {
        InfoList.gameObject.SetActive(true);
        isActive = true;
    }
}
