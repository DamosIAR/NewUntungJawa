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
    [SerializeField] private GameObject minigameMenuCanvas;
    [SerializeField] private GameObject cookGameCanvas;
    [SerializeField] private GameObject BUTTON;
    [SerializeField] private GameObject BUBBLE;

    [SerializeField] private Animator minigameAnimator;
    [SerializeField] private Animator cookgameAnimator;

    private const string MINIGAME = "MiniGame";
    private const string INFO = "Info";
    private const string BACKTOMAINCAMERA = "BackToMainCamera";
    private const string COOKGAME = "CookGame";

    private float startingPoint = 2000;
    private float stoppingPoint = 1484;
    private float speed = 400;

    // Start is called before the first frame update
    void Start()
    {
        minigameMenuCanvas.gameObject.SetActive(false);
        virtualCameraStart.Priority = 15;
        virtualCameraMinigame.Priority = 10;
        InfoVirtualCamera.Priority = 10;
        cookgameVirtualCamera.Priority = 10;
        cookGameCanvas.SetActive(false);

        /*Vector3 currentPosition = virtualCameraStart.transform.position;
        Vector3 newPosition = new Vector3(startingPoint, currentPosition.y, currentPosition.z);*/
        virtualCameraStart.transform.position = new Vector3(startingPoint, 877f, 142f);

        BUTTON.gameObject.SetActive(true);
        BUBBLE.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (startingPoint > stoppingPoint)
        {
            startingPoint -= (speed * Time.deltaTime);
            float newPositionX = startingPoint;
            virtualCameraStart.transform.position = new Vector3(newPositionX, 877f, 142f);
        }

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit) )
            {
                /*if(hit.collider.tag == MINIGAME)
                {
                    virtualCameraMinigame.Priority = 20;
                    minigameMenuCanvas.gameObject.SetActive(true);
                    minigameAnimator.SetBool("IsOpen", true);
                }*/

                if(hit.collider.tag == INFO)
                {
                    InfoVirtualCamera.Priority = 20;
                }
                else if(hit.collider.tag == BACKTOMAINCAMERA)
                {
                    InfoVirtualCamera.Priority = 10;
                    BUTTON.gameObject.SetActive(true);
                    BUBBLE.gameObject.SetActive(true);
                }

                /*if(hit.collider.tag == COOKGAME)
                {
                    cookgameVirtualCamera.Priority = 20;
                    cookGameCanvas.SetActive(true);
                    cookgameAnimator.SetBool("IsOpen", true);
                }*/
            }
        }
    }

    public void backtomaincamera()
    {
        virtualCameraMinigame.Priority = 10;
        cookgameVirtualCamera.Priority = 10;
        minigameAnimator.SetBool("IsOpen", false);
        cookgameAnimator.SetBool("IsOpen", false);
        BUTTON.gameObject.SetActive(true);
        BUBBLE.gameObject.SetActive(true);
        StartCoroutine(waitAfterClose());
    }

    public void CookGameButton()
    {
        cookgameVirtualCamera.Priority = 20;
        cookGameCanvas.SetActive(true);
        cookgameAnimator.SetBool("IsOpen", true);
        BUTTON.gameObject.SetActive(false);
        BUBBLE.gameObject.SetActive(false);
    }

    public void MinigameButton()
    {
        virtualCameraMinigame.Priority = 20;
        minigameMenuCanvas.gameObject.SetActive(true);
        minigameAnimator.SetBool("IsOpen", true);
        BUTTON.gameObject.SetActive(false);
        BUBBLE.gameObject.SetActive(false);
    }

    public void InfoBoardButton()
    {
        InfoVirtualCamera.Priority = 20;
        BUTTON.gameObject.SetActive(false);
        BUBBLE.gameObject.SetActive(false);
    }

    IEnumerator waitAfterClose()
    {
        yield return new WaitForSeconds(0.5f);
        minigameMenuCanvas.gameObject.SetActive(false);
        cookGameCanvas.SetActive(false);
    }
}
