using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IntroductionManager : MonoBehaviour
{
    /*[SerializeField] private TextMeshProUGUI Dialogue;
    [SerializeField] private string[] lines;
    [SerializeField] private GameObject[] Face;
    [SerializeField] private GameObject[] ImagesGuide;
    [SerializeField] private float TextSpeed;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        Dialogue.text = string.Empty;
        startDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (Dialogue.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                Dialogue.text = lines[index];
            }
        }
    }

    void startDialogue()
    {
        index = 0;
        ImagesGuide[index+1].SetActive(false);
        Face[index+1].SetActive(false);
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            Dialogue.text += c;
            yield return new WaitForSeconds(TextSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1 && index < ImagesGuide.Length - 1)
        {
            ImagesGuide[index].SetActive(false);
            Face[index].SetActive(false);
            index++;
            Dialogue.text = string.Empty;
            ImagesGuide[index].SetActive(true);
            Face[index].SetActive(true);
            StartCoroutine(TypeLine());
        }
        else
        {
            ImagesGuide[index].gameObject.SetActive(false );
            Face[index].gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }*/

    public static IntroductionManager Instance;

    public Image characterIcon;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea;
    public GameObject DialogueCanvas;

    private Queue<DialogueLine> lines;

    public bool isDialogueActive = false;

    public float typingSpeed = 0.01f;

    //public Animator animator;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        lines = new Queue<DialogueLine>();
        DialogueCanvas.SetActive(false);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        DialogueCanvas.SetActive(true);
        isDialogueActive = true;


        lines.Clear();

        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            lines.Enqueue(dialogueLine);
        }

        DisplayNextDialogueLine();
    }

    public void DisplayNextDialogueLine()
    {
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLine currentLine = lines.Dequeue();

        characterIcon.sprite = currentLine.character.icon;
        characterName.text = currentLine.character.name;

        StopAllCoroutines();

        StartCoroutine(TypeSentence(currentLine));
    }

    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        dialogueArea.text = "";
        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void EndDialogue()
    {
        isDialogueActive = false;
        DialogueCanvas.SetActive(false);
        //animator.Play("hide");
    }
}
