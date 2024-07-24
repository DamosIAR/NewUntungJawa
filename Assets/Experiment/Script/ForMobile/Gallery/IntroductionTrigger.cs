using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DialogueCharacter
{
    public string name;
    public Sprite icon;
    //public Image arrow;
}
 
[System.Serializable]
public class DialogueLine
{
    public DialogueCharacter character;
    [TextArea(3, 10)]
    public string line;
}
 
[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}
 
public class IntroductionTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameData gameData;
 
    public void TriggerDialogue()
    {
        IntroductionManager.Instance.StartDialogue(dialogue);
    }

    private void Start()
    {
        gameData = SaveSystem.Load();
        if (gameData.TutorialShown == false)
        {
            TriggerDialogue();
        }
        //TriggerDialogue();
    }

    private void Update()
    {
        if (gameData.TutorialShown == true) return;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //Debug.Log("Tes");
            IntroductionManager.Instance.DisplayNextDialogueLine();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "DialogueTrigger")
        {
            TriggerDialogue();
        }
    }

}