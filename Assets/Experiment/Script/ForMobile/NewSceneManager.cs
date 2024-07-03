using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewSceneManager : MonoBehaviour
{
    [SerializeField] private Animator transition;
    [SerializeField] private GameObject StartingTransition;
    [SerializeField] private GameObject EndingTransition;
    private float transitiontime = 1f;
    private int cycle = 1;

    private const string GALLERY = "ExperimentalGallery";
    private const string CRABSPEAR = "CrabSpearing";

    public static NewSceneManager Instance { get; private set; }

    private void Start()
    {
        //StartingTransition.SetActive(false);
        EndingTransition.SetActive(false);
    }

    private void Awake()
    {
        Instance = this;
    }

    public void CookGameButton()
    {
        StartCoroutine(loadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void exitGame() => Application.Quit();

    IEnumerator loadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        EndingTransition.SetActive(true);
        yield return new WaitForSeconds(transitiontime);
        SceneManager.LoadScene(levelIndex);
    }

    public void MainMenuLoadButton()
    {
        Time.timeScale = 1f;
        StartCoroutine(loadLevel(SceneManager.GetActiveScene().buildIndex - SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void PlayAgain()
    {
        Time.timeScale = 1f;
        StartCoroutine(loadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void CookGamePlayAgain()
    {
        StartCoroutine(loadLevel(SceneManager.GetActiveScene().buildIndex));
        cycle++;
    }

    public void CrabSpearMiniGame()
    {
        StartCoroutine(loadLevel(SceneManager.GetActiveScene().buildIndex + 2));
    }

    public void BananaBoatMinigame()
    {
        StartCoroutine(loadLevel(SceneManager.GetActiveScene().buildIndex + 3));
    }

    public void HomeButton()
    {
        StartCoroutine(loadLevel(SceneManager.GetActiveScene().buildIndex - 1));
    }

    public int getCycle()
    {
        return cycle;
    }
}
