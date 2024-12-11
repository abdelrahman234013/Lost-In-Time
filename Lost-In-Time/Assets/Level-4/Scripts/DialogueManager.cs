using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    
    public Image characterIcon;             
    public TextMeshProUGUI characterName;   
    public TextMeshProUGUI dialogueArea;     
    public Button continueButton;            
    public GameObject dialoguePanel;         

   
    public List<string> dialogueLines;       

   
    private Queue<string> sentences;        
    public float typingSpeed = 0.05f;       
    private void Start()
    {
        sentences = new Queue<string>();

        
        dialoguePanel.SetActive(false);

       
        continueButton.onClick.AddListener(DisplayNextLine);

        StartDialogue();
    }

    public void StartDialogue()
    {
        
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

        
        if (sentences.Count == 0)
        {
            
            EndDialogue();
        }
    }

   
    void EndDialogue()
    {
        
        dialoguePanel.SetActive(false);

        
        continueButton.gameObject.SetActive(false);

      
        characterIcon.gameObject.SetActive(false);
        characterName.text = "";                  
        characterIcon.sprite = null;               
        dialogueArea.text = "";                   
    }
}
