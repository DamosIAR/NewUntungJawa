using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewSceneManager : MonoBehaviour
{
    [SerializeField] private Animator transition;
    [SerializeField] private GameObject StartingTransition;
    [SerializeField] private GameObject EndingTransition;
    private float transitiontime = 1f;

    private void Start()
    {
        //StartingTransition.SetActive(false);
        EndingTransition.SetActive(false);
    }

    public void LoadScene()
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
        StartCoroutine(loadLevel(SceneManager.GetActiveScene().buildIndex - 1));
    }

}
