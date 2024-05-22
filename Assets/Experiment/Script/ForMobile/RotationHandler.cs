using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationHandler : MonoBehaviour
{
    [SerializeField] private AnimationCurve rotationCurve;
    [SerializeField] private Vector3 toLeft;
    [SerializeField] private Vector3 toRight;
    //[SerializeField] private float speed = 1f;

    private float current;
    private float target = 20;

    private void Update()
    {

        if (Input.touchCount > 0)
        {
            current = Mathf.MoveTowards(current, target, Time.deltaTime);
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "LeftScreen")
                {
                    transform.Rotate(Vector3.up * rotationCurve.Evaluate(current));
                    //transform.rotation = Quaternion.Lerp(Quaternion.Euler(Vector3.zero), Quaternion.Euler(toLeft), rotationCurve.Evaluate(current));
                }
                else if(hit.collider.tag == "RightScreen")
                {
                    transform.Rotate(Vector3.down * rotationCurve.Evaluate(current));
                    //transform.rotation = Quaternion.Lerp(Quaternion.Euler(Vector3.zero), Quaternion.Euler(toRight), rotationCurve.Evaluate(current));
                }
                //current = Mathf.MoveTowards(target, 0, Time.deltaTime);
            }
        }
        else
        {
            //current = Mathf.MoveTowards(target, 0, Time.deltaTime);
        }



    }

    public void RotateToLeft()
    {

    }

}
