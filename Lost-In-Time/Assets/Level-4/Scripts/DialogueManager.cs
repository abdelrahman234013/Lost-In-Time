using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    // UI Elements
    public Image characterIcon;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea;
    public Button continueButton;

    // Dialogue Data
    public string characterNameText = "Jack";
    public Sprite characterSprite;
    public List<string> dialogueLines;

    // Internal variables
    private Queue<string> sentences;

    public float typingSpeed = 0.05f;

    private void Start()
    {
        sentences = new Queue<string>();

        characterIcon.gameObject.SetActive(false);
        characterName.gameObject.SetActive(false);
        dialogueArea.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(false);

        continueButton.onClick.AddListener(DisplayNextLine);

        StartDialogue();
    }

    public void StartDialogue()
    {
        characterName.text = characterNameText;
        characterIcon.sprite = characterSprite;

        characterIcon.gameObject.SetActive(true);
        characterName.gameObject.SetActive(true);
        dialogueArea.gameObject.SetActive(true);
        continueButton.gameObject.SetActive(true);

        sentences.Clear();

        foreach (string line in dialogueLines)
        {
            sentences.Enqueue(line);
        }

        DisplayNextLine();
    }

    public void DisplayNextLine()
{
    if (sentences.Count == 0)
    {
        EndDialogue();
        return;
    }

    string currentSentence = sentences.Dequeue();
    StopAllCoroutines();
    StartCoroutine(TypeSentence(currentSentence));
}

public void ContinueButtonClicked()
{
    DisplayNextLine();  // Calls the DisplayNextLine method
}



    // Type the sentence letter by letter
    IEnumerator TypeSentence(string sentence)
    {
        dialogueArea.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void EndDialogue()
    {
        characterIcon.gameObject.SetActive(false);
        characterName.gameObject.SetActive(false);
        dialogueArea.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(false);
    }
}
