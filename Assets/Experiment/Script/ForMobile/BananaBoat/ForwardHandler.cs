using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardHandler : MonoBehaviour
{
    [SerializeField] private AnimationCurve SpeedCurve;

    public static ForwardHandler Instance { get; private set; }

    private float TimePassed = 0f;
    private float MoveForward;

    private void Awake()
    {
        Instance = this;
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

    public float GetForce()
    {
        return MoveForward;
    }
}
