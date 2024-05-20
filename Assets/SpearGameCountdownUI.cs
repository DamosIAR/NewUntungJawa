using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpearGameCountdownUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownUI;


    // Start is called before the first frame update
    void Start()
    {
        SpearGameManager.Instance.StateChanged += SpearGameManager_StateChanged;
    }

    private void SpearGameManager_StateChanged(object sender, System.EventArgs e)
    {
        if(SpearGameManager.Instance.isTutorial())
        {

        }
        else
        {

        }

        if (SpearGameManager.Instance.isCountdown())
        {

        }
        else
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        countdownUI.text = Mathf.Ceil(SpearGameManager.Instance.get).ToString();
    }
}
