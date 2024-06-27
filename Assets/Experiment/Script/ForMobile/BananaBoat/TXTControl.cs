using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TXTControl : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextKiri;
    [SerializeField] private TextMeshProUGUI TextKanan;

    // Start is called before the first frame update
    void Start()
    {
        BananaBoatGameManager.Instance.OnStateChanged += BananaBoatGameManager_OnStateChanged;
        hideTXT();
    }

    private void BananaBoatGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (BananaBoatGameManager.Instance.isCountown())
        {
            showTXT();
        }
        else
        {
            hideTXT();
        }
    }

    private void showTXT()
    {
        TextKiri.gameObject.SetActive(true);
        TextKanan.gameObject.SetActive(true);
    }

    private void hideTXT()
    {
        TextKiri.gameObject.SetActive(false);
        TextKanan.gameObject.SetActive(false);
    }
}
