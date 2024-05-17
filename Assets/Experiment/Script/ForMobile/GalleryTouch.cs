using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GalleryTouch : MonoBehaviour
{
    public Camera mainCamera;
    [SerializeField] private CinemachineVirtualCamera virtualCameraStart;
    [SerializeField] private CinemachineVirtualCamera virtualCameraMinigame;
    [SerializeField] private CinemachineVirtualCamera InfoVirtualCamera;
    [SerializeField] private Canvas minigameMenuCanvas;

    private const string MINIGAME = "MiniGame";
    private const string INFO = "Info";
    private const string BACKTOMAINCAMERA = "BackToMainCamera";

    // Start is called before the first frame update
    void Start()
    {
        minigameMenuCanvas.gameObject.SetActive(false);
        virtualCameraStart.Priority = 15;
        virtualCameraMinigame.Priority = 10;
        InfoVirtualCamera.Priority = 10;
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
                    virtualCameraMinigame.Priority = 20;
                    minigameMenuCanvas.gameObject.SetActive(true);
                }

                if(hit.collider.tag == INFO)
                {
                    InfoVirtualCamera.Priority = 20;
                }
                else if(hit.collider.tag == BACKTOMAINCAMERA)
                {
                    InfoVirtualCamera.Priority = 10;
                }
            }
        }
    }

    public void backtomaincamera()
    {
        virtualCameraMinigame.Priority = 10;
        minigameMenuCanvas.gameObject.SetActive(false );
    }
}
