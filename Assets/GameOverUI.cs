using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI GameOverText;
    [SerializeField] private Canvas GameOverCanvas;
    [SerializeField] private TextMeshProUGUI RecipeDeliveredText;
    [SerializeField] private TextMeshProUGUI RecipeFailedText;

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
            RecipeDeliveredText.text = "Recipe Delivered : " + DeliveryManager.Instance.GetSuccessfulDeliveryAmount().ToString();
            RecipeFailedText.text = "Wrong Recipe Delivered : " + DeliveryManager.Instance.GetFaildeDeliveryAmount().ToString();
        }
        else
        {
            hide();
        }
    }


    public void show()
    {
        gameObject.SetActive(true);
    }

    private void hide()
    {
        gameObject.SetActive(false);
    }
}
