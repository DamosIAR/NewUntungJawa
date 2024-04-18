using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private Grill grill;
    [SerializeField] private Image sliderTimer;

    private void Start()
    {
        grill.OnProgressChanged += Grill_OnProgressChanged;
        sliderTimer.fillAmount = 0f;
    }

    private void Grill_OnProgressChanged(object sender, Grill.OnProgressChangedEventArgs e)
    {
        sliderTimer.fillAmount = e.progressNormalized;

        if(e.progressNormalized == 0f || e.progressNormalized == 1f)
        {
            hide();
        }
        else
        {
            show();
        }
    }

    private void show()
    {
        gameObject.SetActive(true);
    }

    private void hide()
    {
        gameObject.SetActive(false);
    }
}
