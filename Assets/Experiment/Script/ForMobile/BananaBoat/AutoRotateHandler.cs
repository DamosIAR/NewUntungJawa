using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotateHandler : MonoBehaviour
{
    private float interval = 2f;
    private float IntervalTimeElapsed = 0;
    private int RandomAction;

    private void Start()
    {
        RandomAction = Random.Range(0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (!BananaBoatGameManager.Instance.isPlaying()) return;

        IntervalTimeElapsed += Time.deltaTime;
        if (IntervalTimeElapsed >= interval)
        {
            
            IntervalTimeElapsed = 0;
            RandomAction = Random.Range(0, 10);
            Debug.Log(RandomAction);
        }

        if (RandomAction >= 0 && RandomAction <= 5)
        {
            transform.Rotate(Vector3.back * ForwardHandler.Instance.GetForce() * 2 * Time.deltaTime);
        }
        else
        {
            transform.Rotate(Vector3.forward * ForwardHandler.Instance.GetForce() * 2 * Time.deltaTime);
        }
    }
}
