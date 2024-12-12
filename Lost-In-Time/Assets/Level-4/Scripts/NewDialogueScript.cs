using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NewDialogueScript : MonoBehaviour
{
    
    public Image characterIcon; 
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea; 
    public GameObject dialoguePanel;

   
    public List<string> dialogueLines;
    
    private Queue<string> sentences;

    public float typingSpeed = 0.05f;


    private void Start()
    {
        sentences = new Queue<string>(); 

        // Setup initial UI state
        characterIcon.gameObject.SetActive(false);
        characterName.gameObject.SetActive(false);
        dialogueArea.gameObject.SetActive(false);
        dialoguePanel.SetActive(false);

        
        StartDialogue();
    }

    
    public void StartDialogue()
    {
        
        characterName.text = "Jack"; 

       
        characterIcon.gameObject.SetActive(true);
        characterName.gameObject.SetActive(true);
        dialogueArea.gameObject.SetActive(true);
        dialoguePanel.SetActive(true);

        
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

    
    IEnumerator TypeSentence(string sentence)
    {
        dialogueArea.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

<<<<<<< Updated upstream
        // Delay before the next sentence
        yield return new WaitForSeconds(1f);
=======
       
        yield return new WaitForSeconds(2f);
>>>>>>> Stashed changes
        DisplayNextLine();
    }

    
    void EndDialogue()
    {
        
        characterIcon.gameObject.SetActive(false);
        characterName.gameObject.SetActive(false);
        dialogueArea.gameObject.SetActive(false);
        dialoguePanel.SetActive(false);
    }
}
