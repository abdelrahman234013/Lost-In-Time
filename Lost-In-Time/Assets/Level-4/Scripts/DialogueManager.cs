using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    // UI Elements
    public Image characterIcon;  // Jack's picture (assign in Inspector)
    public TextMeshProUGUI characterName;  // Jack's name (assign in Inspector)
    public TextMeshProUGUI dialogueArea;  // The area that shows the dialogue text
    public Button continueButton;  // The button to continue dialogue

    // Dialogue Data
    public string characterNameText = "Jack";  // Character's name
    public Sprite characterSprite;  // Jack's character sprite (assign in Inspector)
    public List<string> dialogueLines;  // List of dialogue lines to be displayed

    // Internal variables
    private Queue<string> sentences;  // Queue to hold the sentences

    public float typingSpeed = 0.05f;  // Speed of text typing effect

    private void Start()
    {
        sentences = new Queue<string>();  // Initialize the queue

        // Setup initial UI state
        characterIcon.gameObject.SetActive(false);
        characterName.gameObject.SetActive(false);
        dialogueArea.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(false);

        continueButton.onClick.AddListener(DisplayNextLine);  // Button event to display the next line

        // Start the dialogue immediately (or you can call StartDialogue from a trigger)
        StartDialogue();
    }

    // Start the dialogue by clearing any old sentences and filling the queue
    public void StartDialogue()
    {
        // Set the character's name and picture
        characterName.text = characterNameText;
        characterIcon.sprite = characterSprite;

        // Show the UI elements
        characterIcon.gameObject.SetActive(true);
        characterName.gameObject.SetActive(true);
        dialogueArea.gameObject.SetActive(true);
        continueButton.gameObject.SetActive(true);  // Show continue button

        // Clear previous sentences
        sentences.Clear();

        // Enqueue the dialogue lines
        foreach (string line in dialogueLines)
        {
            sentences.Enqueue(line);
        }

        // Display the first sentence
        DisplayNextLine();
    }

    // Display the next line of dialogue
    public void DisplayNextLine()
    {
        // Check if there are no more lines
        if (sentences.Count == 0)
        {
            EndDialogue();  // End the dialogue if no more sentences are left
            return;
        }

        // Get the next sentence from the queue
        string currentSentence = sentences.Dequeue();

        // Stop any ongoing typing coroutine and start a new one
        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentSentence));
    }

    // Type the sentence letter by letter
    IEnumerator TypeSentence(string sentence)
    {
        dialogueArea.text = "";  // Clear previous sentence
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);  // Wait for the typing speed before showing the next letter
        }
    }

    // End the dialogue and hide the UI elements
    void EndDialogue()
    {
        // Hide all UI elements (including dialogue text)
        characterIcon.gameObject.SetActive(false);
        characterName.gameObject.SetActive(false);
        dialogueArea.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(false);
    }
}
