using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SideMovement : MonoBehaviour
{
    ScoreManager scoring;
    public float moveSpeed = 5f;
    Vector3 sideMove = Vector3.zero;

    private void Start()
    {
        //scoring = GameObject.FindGameObjectWithTag("DestroyBarrier").GetComponent<ScoreManager>();
        gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        sideMove.x = 1f;
        transform.position += sideMove * moveSpeed * Time.deltaTime;


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "DestroyBarrier")
        {
            //scoring.updateScore();
            //Destroy(GameObject);
        }
    }
}
