using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTouch : MonoBehaviour
{
    public NewSceneManager sceneManager;
    public AnimationManager startAnim;
    public AnimationManager exitAnim;
    public Camera mainCamera;

    private void Start()
    {
        startAnim = GameObject.FindGameObjectWithTag("Start").GetComponent<AnimationManager>();
        sceneManager = GameObject.FindAnyObjectByType<NewSceneManager>();
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit);
                if (hit.collider.tag == "Start")
                {
                    startAnim.startButton();

                    sceneManager.LoadScene();
                }
                else if(hit.collider.tag == "Exit")
                {
                    exitAnim.exitButton();

                    sceneManager.exitGame();
                }
            }
        }
    }

    
}
