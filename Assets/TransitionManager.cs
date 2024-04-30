using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionManager : MonoBehaviour
{
    [SerializeField] private GameObject startingSceneTransition;
    [SerializeField] private GameObject endingSceneTransition;

    private void Start()
    {
        startingSceneTransition.SetActive(true);
    }
}
