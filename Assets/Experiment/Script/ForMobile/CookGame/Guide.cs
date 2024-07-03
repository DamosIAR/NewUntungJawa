using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.CullingGroup;

public class Guide : MonoBehaviour
{
    [SerializeField] private GameObject[] HelpImage;
    [SerializeField] private GameObject NextButton;
    [SerializeField] private GameObject PrevButton;

    private bool isNotActive;
    private int currentIndex;

    private void Start()
    {
        if(HelpImage.Length > 0)
        {
            for(int i = 0; i < HelpImage.Length; i++)
            {
                HelpImage[i].SetActive(false);
                //HelpImage[i].SetActive(i == currentIndex);
            }
        }
        NextButton.SetActive(false);
        PrevButton.SetActive(false);
        isNotActive = true;
    }

    public void ShowHideGuide()
    {
        if (isNotActive)
        { 
            Debug.Log("Aktif");
            if (HelpImage.Length > 0)
            {
                for (int i = 0; i < HelpImage.Length; i++)
                {
                    HelpImage[i].SetActive(i == currentIndex);
                }
            }
            NextButton.SetActive(true);
            isNotActive = false;
        }
    }

    public void NextImage()
    {
        HelpImage[currentIndex].SetActive(false);

        currentIndex++;
        if(currentIndex < HelpImage.Length)
        {
            HelpImage[currentIndex].SetActive(true);
            PrevButton.SetActive(true);
        }
        else if(currentIndex == HelpImage.Length)
        {
            currentIndex = 0;
            NextButton.SetActive(false);
            PrevButton.SetActive(false);
            isNotActive=true;
            Debug.Log("Tidak Aktif");
        }
    }

    public void PreviousImage()
    {
        HelpImage[currentIndex].SetActive(false);
        currentIndex--;
        HelpImage[currentIndex].SetActive(true);
        PrevButton.SetActive(false);

    }
}
