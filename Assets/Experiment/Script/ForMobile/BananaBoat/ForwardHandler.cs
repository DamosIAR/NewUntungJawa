using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardHandler : MonoBehaviour
{
    [SerializeField] private AnimationCurve SpeedCurve;

    private float TimePassed = 0f;
    private float MoveForward;
    private GameObject Player;
    

    private void Start()
    {
        transform.position = Vector3.zero;
    }

    void Update()
    {
        if (!BananaBoatGameManager.Instance.isPlaying()) return;
        TimePassed += Time.deltaTime;
        MoveForward = Mathf.RoundToInt(SpeedCurve.Evaluate(TimePassed));
        //transform.position += (Vector3.forward * MoveForward * Time.deltaTime);
        transform.position += new Vector3(0, 0, (MoveForward * Time.deltaTime));
    }
}
