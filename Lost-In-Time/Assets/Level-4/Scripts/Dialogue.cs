using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
     public TextMeshProUGUI textDisplay; //a special variable that holds the TextMeshPro Text for manipulation
    private string[] dialogueSentences; //an array that stores all the sentences to be displayed

    private int index = 0; //a variable that signifies which sentence is being printed or to be printed
    public float typingSpeed; //a variable to control the speed of the typewriter effect

    public GameObject continueButton; //a variable that holds the continue button
    public GameObject dialogueBox; //a variable that holds the panel (dialogue box)

    public Rigidbody2D player; //a variable that holds the player's/character's Rigidbody2D component

    void Start()
    {
      

        dialogueBox.SetActive(false);
        continueButton.SetActive(false);
    }

    void Update()
    {

    }


public IEnumerator TypeDialogue()
{
    dialogueBox.SetActive(true); // enables the dialogue box
    player.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

    foreach (char letter in dialogueSentences[index].ToCharArray()) // converting the sentence into an array of characters
    {
        textDisplay.text += letter; // adding each character to the displayed text

        yield return new WaitForSeconds(typingSpeed); // this special type of return is used to pause the execution of this function (TypeDialogue) for the specified (typingSpeed) amount of seconds. After the specified amount of seconds has passed, this function (TypeDialogue) continues its execution

        if (textDisplay.text == dialogueSentences[index]) // checks if the whole sentence has been displayed
        {
            continueButton.SetActive(true);
        }
    }
}


public void SetSentences(string[] sentences) // sets the sentences array to the passed one
{
    this.dialogueSentences = sentences;
}


public void NextSentence() // This function, if able, is used to increment the index which in turn moves the dialogue to the next sentence
{
    continueButton.SetActive(false); // Disables the continue button to avoid bugs

    if (index < dialogueSentences.Length - 1) // If there are more sentences then
    {
        index++; // Move to the next sentence
        textDisplay.text = ""; // Clear the displayed text
        StartCoroutine(TypeDialogue()); // Start the coroutine again to display the new sentence
    }
    else
    {
        // This section gets executed when all sentences have been displayed
        textDisplay.text = ""; // Clear the displayed text
        continueButton.SetActive(false); // Disable the continue button
        dialogueBox.SetActive(false); // Disable the dialogue box
        this.dialogueSentences = null; // Clear the sentences array
        index = 0; // Reset the index
        player.constraints = RigidbodyConstraints2D.None; // Unfreeze the player
        player.constraints = RigidbodyConstraints2D.FreezeRotation; // Freeze the player's rotation as it was before
         Destroy(player.gameObject);
    }
}

}
