using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClipSO audioClipSO;

    // Start is called before the first frame update
    void Start()
    {
        DeliveryManager.Instance.onRecipeSuccess += DeliveryManager_onRecipeSuccess;
        DeliveryManager.Instance.onRecipeFailed += DeliveryManager_onRecipeFailed;
        PlateCabinet.onPlatePickup += PlateCabinet_onPlatePickup1;
        Box.onIngredientPickup += Box_onIngredientPickup1;
        SauceTable.onSaucePickedUp += SauceTable_onSaucePickedUp;
        Trash.onObjectThrown += Trash_onObjectThrown;
        TouchExample.Instance.onDirectionChanged += TouchExample_onDirectionChanged;
        CookGameManager.Instance.OnGateMove += CookGameManager_OnGateMove;
        CookGameManager.Instance.OnTimeAboutToEnd += CookGameManager_OnTimeAboutToEnd;
    }

    private void CookGameManager_OnTimeAboutToEnd(object sender, System.EventArgs e)
    {
        DeliveryManager deliveryManager = DeliveryManager.Instance;
        playSound(audioClipSO.timerWarning, deliveryManager.transform.position);
    }

    private void CookGameManager_OnGateMove(object sender, System.EventArgs e)
    {
        playSound(audioClipSO.GateCloseOpen, Camera.main.transform.position);
    }

    private void TouchExample_onDirectionChanged(object sender, System.EventArgs e)
    {
        playSound(audioClipSO.buttonPressed, Camera.main.transform.position);
    }

    private void Trash_onObjectThrown(object sender, System.EventArgs e)
    {
        playSound(audioClipSO.objectGrab, Camera.main.transform.position);
    }

    private void SauceTable_onSaucePickedUp(object sender, System.EventArgs e)
    {
        playSound(audioClipSO.objectGrab, Camera.main.transform.position);
    }

    private void PlateCabinet_onPlatePickup1(object sender, System.EventArgs e)
    {
        PlateCabinet plateCabinet = PlateCabinet.Instance;
        playSound(audioClipSO.platePickup, Camera.main.transform.position);
    }

    private void Box_onIngredientPickup1(object sender, System.EventArgs e)
    {
        Box box = Box.Instance;
        playSound(audioClipSO.ingredientPickup, Camera.main.transform.position);
    }

    private void DeliveryManager_onRecipeFailed(object sender, System.EventArgs e)
    {
        playSound(audioClipSO.RecipeWrong, Camera.main.transform.position);
    }

    private void DeliveryManager_onRecipeSuccess(object sender, System.EventArgs e)
    {
        playSound(audioClipSO.RecipeCorrect, Camera.main.transform.position);
    }

    private void playSound(AudioClip audioClip, Vector3 position, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volume);
    }
}
