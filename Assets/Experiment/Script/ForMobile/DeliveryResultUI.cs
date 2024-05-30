using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryResultUI : MonoBehaviour
{
    private const string POPUP = "Popup";

    [SerializeField] private Image iconImage;
    [SerializeField] private Sprite failedSprite;
    [SerializeField] private Sprite CorrectImage;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        DeliveryManager.Instance.onRecipeSuccess += DeliveryManager_onRecipeSuccess;
        DeliveryManager.Instance.onRecipeFailed += DeliveryManager_onRecipeFailed;
        gameObject.SetActive(false);
    }

    private void DeliveryManager_onRecipeFailed(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);
        iconImage.sprite = failedSprite;
        animator.SetTrigger(POPUP);
        /*backgroundImage.color = failedColor;
        iconImage.sprite = failedSprite;
        messageText.text = "MASAKAN\nSALAH";*/
    }

    private void DeliveryManager_onRecipeSuccess(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);
        iconImage.sprite = CorrectImage;
        animator.SetTrigger(POPUP);
        /*backgroundImage.color = successColor;
        iconImage.sprite = successSprite;
        messageText.text = "MASAKAN\nBENAR";*/
    }
}
