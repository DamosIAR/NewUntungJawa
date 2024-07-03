using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrillVisual : MonoBehaviour
{
    [SerializeField] private Grill grill;
    [SerializeField] private GameObject particleGameObject;

    private void Start()
    {
        grill.OnStateChanged += Grill_OnStateChanged;
    }

    private void Grill_OnStateChanged(object sender, Grill.OnStateChangedEventArgs e)
    {
        bool showVisual = e.state == Grill.State.Grilling || e.state == Grill.State.Grilled;
        particleGameObject.SetActive(showVisual);
    }
}
