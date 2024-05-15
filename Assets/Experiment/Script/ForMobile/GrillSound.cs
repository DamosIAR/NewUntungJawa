using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrillSound : MonoBehaviour
{
    [SerializeField] private Grill grill;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        grill.OnStateChanged += Grill_OnStateChanged;
    }

    private void Grill_OnStateChanged(object sender, Grill.OnStateChangedEventArgs e)
    {
        bool playSound = e.state == Grill.State.Grilling || e.state == Grill.State.Grilled;
        if(playSound)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Pause();
        }
    }
}
