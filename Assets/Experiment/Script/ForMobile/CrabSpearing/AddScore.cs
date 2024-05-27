using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    ScoreManager scoreManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Spear")
        {
            Debug.Log("add score");
            scoreManager.updateScore();
        }
    }
}
