using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI GameOverText;
    [SerializeField] private Canvas GameOverCanvas;

    private void Start()
    {
        CookGameManager.Instance.OnStateChanged += CookGameManager_OnStateChanged;
        hide();
    }

    private void CookGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (CookGameManager.Instance.isGameOver())
        {
            show();
        }
        else
        {
            hide();
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
