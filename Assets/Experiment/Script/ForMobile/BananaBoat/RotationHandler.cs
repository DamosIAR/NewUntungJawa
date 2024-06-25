using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationHandler : MonoBehaviour
{
    public static RotationHandler Instance { get; private set; }

    [SerializeField] private AnimationCurve rotationCurve;

    private float hold = 0f;
    private float force;

    bool left;

    private void Awake()
    {
        Instance = this;
        transform.eulerAngles = Vector3.zero;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            if (!BananaBoatGameManager.Instance.isPlaying()) return;
            hold += Time.deltaTime;
            force = Mathf.RoundToInt(rotationCurve.Evaluate(hold));
            //current = Mathf.MoveTowards(current, target, Time.deltaTime);
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "LeftScreen")
                {
                    transform.Rotate(Vector3.forward * force * Time.deltaTime);
                    left = true;
                    //transform.Rotate(Vector3.up * rotationCurve.Evaluate(current));
                    //transform.rotation = Quaternion.Lerp(Quaternion.Euler(Vector3.zero), Quaternion.Euler(toLeft), rotationCurve.Evaluate(current));
                }
                else if(hit.collider.tag == "RightScreen")
                {
                    transform.Rotate(Vector3.back * force * Time.deltaTime);
                    left = false;
                    //transform.Rotate(Vector3.down * rotationCurve.Evaluate(current));
                    //transform.rotation = Quaternion.Lerp(Quaternion.Euler(Vector3.zero), Quaternion.Euler(toRight), rotationCurve.Evaluate(current));
                }
            }
        }
        else
        {
            if (hold > 0f)
            {
                if (!BananaBoatGameManager.Instance.isPlaying()) return;
                hold -= Time.deltaTime * 2;
                force = Mathf.RoundToInt(rotationCurve.Evaluate(hold));
                if(left)
                {
                    transform.Rotate(Vector3.forward * force * Time.deltaTime);

                }
                else
                {
                    transform.Rotate(Vector3.back * force * Time.deltaTime);

                }
            }
        }
        //Debug.Log(GetRotation());
    }

    public float getForce()
    {
        return force;
    }

    public Vector3 GetRotation()
    {
        return transform.eulerAngles;
    }

    public void RotateToLeft()
    {
        if (!BananaBoatGameManager.Instance.isPlaying()) return;
        hold += Time.deltaTime;
        force = Mathf.RoundToInt(rotationCurve.Evaluate(hold));
        transform.Rotate(Vector3.up * force * Time.deltaTime);
        left = true;
    }

    public void RotateToRight()
    {
        if (!BananaBoatGameManager.Instance.isPlaying()) return;
        hold += Time.deltaTime;
        force = Mathf.RoundToInt(rotationCurve.Evaluate(hold));
        transform.Rotate(Vector3.down * force * Time.deltaTime);
        left = false;
    }
}
