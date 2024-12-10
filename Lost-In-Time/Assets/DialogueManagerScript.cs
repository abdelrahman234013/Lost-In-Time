using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManagerScript : MonoBehaviour
{
    public static DialogueManagerScript Instance;

    public Image characterIcon;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea;

    private Queue<DialogueLine> lines;

    public bool isDialogueActive = false;

    public float typingSpeed = 0.2f;

    public Animator animator;

    public GameObject bird; // Reference to the bird GameObject
    public GameObject dialogueBox; // Reference to the dialogue box GameObject

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        lines = new Queue<DialogueLine>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        isDialogueActive = true;

        // Show the bird and the dialogue box together
        if (bird != null)
        {
            bird.SetActive(true); // Make the bird visible
        }

        if (dialogueBox != null)
        {
            dialogueBox.SetActive(true); // Make the dialogue box visible
        }

        animator.Play("show");

        lines.Clear();

        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            lines.Enqueue(dialogueLine);
        }

        DisplayNextDialogueLine();
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

        // Hide the bird and the dialogue box together
        if (bird != null)
        {
            bird.SetActive(false); // Hide the bird
        }

        if (dialogueBox != null)
        {
            dialogueBox.SetActive(false); // Hide the dialogue box
        }

        animator.Play("hide");
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

}