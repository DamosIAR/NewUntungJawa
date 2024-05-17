using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GalleryTouch : MonoBehaviour
{
    public Camera mainCamera;
    [SerializeField] private CinemachineVirtualCamera virtualCameraStart;
    [SerializeField] private CinemachineVirtualCamera virtualCameraMinigame;
    [SerializeField] private Canvas minigameMenuCanvas;

    private const string MINIGAME = "MiniGame";

    // Start is called before the first frame update
    void Start()
    {
        minigameMenuCanvas.gameObject.SetActive(false);
        virtualCameraStart.Priority = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit) )
            {
                if(hit.collider.tag == MINIGAME)
                {
                    virtualCameraStart.Priority = 7;
                    minigameMenuCanvas.gameObject.SetActive(true);
                }
            }
        }
    }

    public void backtomaincamera()
    {
        virtualCameraStart.Priority = 20;
        minigameMenuCanvas.gameObject.SetActive(false );
    }
}
