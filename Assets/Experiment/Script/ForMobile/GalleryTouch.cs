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
    [SerializeField] private CinemachineVirtualCamera cookgameVirtualCamera;
    [SerializeField] private Canvas minigameMenuCanvas;
    [SerializeField] private GameObject cookGameCanvas;

    private const string MINIGAME = "MiniGame";
    private const string INFO = "Info";
    private const string BACKTOMAINCAMERA = "BackToMainCamera";
    private const string COOKGAME = "CookGame";

    // Start is called before the first frame update
    void Start()
    {
        minigameMenuCanvas.gameObject.SetActive(false);
        virtualCameraStart.Priority = 15;
        virtualCameraMinigame.Priority = 10;
        InfoVirtualCamera.Priority = 10;
        cookgameVirtualCamera.Priority = 10;
        cookGameCanvas.SetActive(false);
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

                if(hit.collider.tag == COOKGAME)
                {
                    cookgameVirtualCamera.Priority = 20;
                    cookGameCanvas.SetActive(true);
                }
            }
        }
    }

    public void backtomaincamera()
    {
        virtualCameraMinigame.Priority = 10;
        cookgameVirtualCamera.Priority = 10;
        minigameMenuCanvas.gameObject.SetActive(false );
        cookGameCanvas.SetActive(false);
    }
}
