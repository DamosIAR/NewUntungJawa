using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBtnGallery : MonoBehaviour
{
    [SerializeField] private GameObject menuBtnCanvas;
    [SerializeField] private GameObject dropDownButton;
    [SerializeField] private GameObject flyUpButton;

    public Animator animator;
    public static MenuBtnGallery instance {  get; private set; }

    private void Start()
    {
        instance = this;
        menuBtnCanvas.gameObject.SetActive(false);
        dropDownButton.gameObject.SetActive(true);
        flyUpButton.gameObject.SetActive(false);
    }

    public void dropbuttonpressed()
    {
        menuBtnCanvas.gameObject.SetActive(true);
        dropDownButton.gameObject.SetActive(false);
        flyUpButton.gameObject.SetActive(true) ;
        animator.SetBool("Drop", true);
    }

    public void flybuttonpressed()
    {
        StartCoroutine(flyup());
    }

    IEnumerator flyup()
    {
        animator.SetBool("Drop", false);
        yield return new WaitForSeconds(0.5f);
        menuBtnCanvas.gameObject.SetActive(false);
        dropDownButton.gameObject.SetActive(true);
        flyUpButton.gameObject.SetActive(false);
    }

    public void ForceCloseMenu()
    {
        menuBtnCanvas.gameObject.SetActive(false);
        dropDownButton.gameObject.SetActive(true);
        flyUpButton.gameObject.SetActive(false);
    }
}
