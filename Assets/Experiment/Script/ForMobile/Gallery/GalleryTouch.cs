using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class GalleryTouch : MonoBehaviour
{
    public Camera mainCamera;
    public static GalleryTouch instance { get; private set; }

    [SerializeField] private CinemachineVirtualCamera virtualCameraStart;
    [SerializeField] private CinemachineVirtualCamera virtualCameraMinigame;
    [SerializeField] private CinemachineVirtualCamera InfoVirtualCamera;
    [SerializeField] private CinemachineVirtualCamera cookgameVirtualCamera;
    [SerializeField] private CinemachineVirtualCamera shopVirtualCamera;
    [SerializeField] private GameObject minigameMenuCanvas;
    [SerializeField] private GameObject cookGameCanvas;
    [SerializeField] private GameObject BUTTON;
    [SerializeField] private GameObject BUBBLE;
    [SerializeField] private GameObject ImageInfo;
    [SerializeField] private GameObject InfoCanvas;
    [SerializeField] private GameObject ShopCanvas;

    [SerializeField] private Animator minigameAnimator;
    [SerializeField] private Animator cookgameAnimator;
    [SerializeField] private Animator shopAnimator;

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
        instance = this;
        minigameMenuCanvas.gameObject.SetActive(false);
        virtualCameraStart.Priority = 15;
        virtualCameraMinigame.Priority = 10;
        InfoVirtualCamera.Priority = 10;
        cookgameVirtualCamera.Priority = 10;
        shopVirtualCamera.Priority = 10;
        cookGameCanvas.SetActive(false);

        virtualCameraStart.transform.position = new Vector3(startingPoint, 877f, 142f);

        BUTTON.gameObject.SetActive(true);
        BUBBLE.gameObject.SetActive(true);
        ImageInfo.gameObject.SetActive(false);
        InfoCanvas.gameObject.SetActive(false);
        //InfoManager.instance.DisableInfoCanvas();
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

        /*if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit) )
            {
                *//*if(hit.collider.tag == MINIGAME)
                {
                    virtualCameraMinigame.Priority = 20;
                    minigameMenuCanvas.gameObject.SetActive(true);
                    minigameAnimator.SetBool("IsOpen", true);
                }*/

                /*if(hit.collider.tag == INFO)
                {
                    InfoVirtualCamera.Priority = 20;
                }*/
                /*if(hit.collider.tag == BACKTOMAINCAMERA)
                {
                    InfoVirtualCamera.Priority = 10;
                    BUTTON.gameObject.SetActive(true);
                    BUBBLE.gameObject.SetActive(true);
                    ImageInfo.gameObject.SetActive(false);
                }*/

                /*if(hit.collider.tag == COOKGAME)
                {
                    cookgameVirtualCamera.Priority = 20;
                    cookGameCanvas.SetActive(true);
                    cookgameAnimator.SetBool("IsOpen", true);
                }*//*
            }
        }*/
    }

    public void backtomaincamera()
    {
        virtualCameraMinigame.Priority = 10;
        cookgameVirtualCamera.Priority = 10;
        InfoVirtualCamera.Priority = 10;
        shopVirtualCamera.Priority = 10;
        minigameAnimator.SetBool("IsOpen", false);
        cookgameAnimator.SetBool("IsOpen", false);
        shopAnimator.SetBool("IsShopOpen", false);
        BUBBLE.gameObject.SetActive(true);
        ImageInfo.gameObject.SetActive(false);
        InfoCanvas.gameObject.SetActive(false);
        //ShopCanvas.gameObject.SetActive(false);
        InfoManager.instance.DisableInfoCanvas();
        StartCoroutine(waitAfterClose());
        BUTTON.gameObject.SetActive(true);
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
        StartCoroutine(waitAfterTriggerInfo());
        BUTTON.gameObject.SetActive(false);
        BUBBLE.gameObject.SetActive(false);
    }

    public void ShopBoardButton()
    {
        shopVirtualCamera.Priority = 20;
        ShopCanvas.gameObject.SetActive(true);
        shopAnimator.SetBool("IsShopOpen", true);
        BUTTON.gameObject.SetActive(false);
        BUBBLE.gameObject.SetActive(false);
    }

    IEnumerator waitAfterClose()
    {
        yield return new WaitForSeconds(0.5f);
        minigameMenuCanvas.gameObject.SetActive(false);
        cookGameCanvas.SetActive(false);
    }

    IEnumerator waitAfterTriggerInfo()
    {
        yield return new WaitForSeconds(1f);
        ImageInfo.gameObject.SetActive(true);
        InfoCanvas.gameObject.SetActive(true);
        InfoManager.instance.EnableInfoCanvas();
    }

    IEnumerator waitAfterTriggerShop()
    {
        yield return new WaitForSeconds(1f);
        ShopCanvas.SetActive(true);
    }
}
