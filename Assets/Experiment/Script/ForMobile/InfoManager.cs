using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoManager : MonoBehaviour
{
    [SerializeField] private Image HutanMangrove;
    [SerializeField] private Image PantaiSakura;
    [SerializeField] private Image TuguArungSamudra;
    [SerializeField] private Image TamanNemo;
    [SerializeField] private Image JembatanPengantin;
    [SerializeField] private Image KampungJepang;
    [SerializeField] private Image PantaiArsa;
    [SerializeField] private Image BananaBoat;

    [SerializeField] private GameObject VirtualCameraLookAt;

    private bool Active;
    private bool ButtonActive;
    private Image activeImage = null;


    private void Start()
    {
        HutanMangrove.gameObject.SetActive(false);
        PantaiSakura.gameObject.SetActive(false);
        TuguArungSamudra.gameObject.SetActive(false);
        TamanNemo.gameObject.SetActive(false);
        JembatanPengantin.gameObject.SetActive(false);
        KampungJepang.gameObject.SetActive(false);
        PantaiArsa.gameObject.SetActive(false);
        BananaBoat.gameObject.SetActive(false);
        Active = false;
        ButtonActive = false;
}

    public void HutanMangroveBtn()
    {
        ToggleObject(HutanMangrove);
    }

    public void PantaiSakuraBtn()
    {
        ToggleObject(PantaiSakura);
    }
    
    public void TuguArungSamudraBtn()
    {
        ToggleObject(TuguArungSamudra);
    }

    public void TamanNemoBtn()
    {
        ToggleObject(TamanNemo);
    }
    
    public void JembatanPengantinBtn()
    {
        ToggleObject(JembatanPengantin);
        
    }
    
    public void KampungJepangBtn()
    {
        ToggleObject(KampungJepang);
        
    }
    
    public void PantaiArsaBtn()
    {
        ToggleObject(PantaiArsa);
        
    }

    public void BananaBoatBtn()
    {
        ToggleObject(BananaBoat);
    }

    public void ToggleObject(Image img)
    {
        if (activeImage == null)
        {
            // No object is active, activate the clicked object
            img.gameObject.SetActive(true);
            activeImage = img;
            Debug.Log(VirtualCameraLookAt.transform.position);
        }
        else if (activeImage == img)
        {
            // The clicked object is already active, deactivate it
            img.gameObject.SetActive(false);
            activeImage = null;
        }
        // If a different object is active, do nothing (no else clause needed)
    }


}
