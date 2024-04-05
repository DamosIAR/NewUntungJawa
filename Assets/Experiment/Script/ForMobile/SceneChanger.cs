using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class SceneChanger : MonoBehaviour
{
    public static SceneChanger instance;
    public string SceneName;
    [SerializeField] Animator transitionAnim;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
       
    public enum Scene
    {
        MainMenu,
        Gallery,
        CrabSpearing,
        CookGame
    }

    public void LoadScene()
    {
        StartCoroutine(loadlevel());
    }

    IEnumerator loadlevel()
    {
        transitionAnim.SetBool("SceneChanging", true);
        yield return new WaitForSeconds(0.3f);
       SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex+1);
        transitionAnim.SetBool("SceneChanging", false);
    }

    public void loadMenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
