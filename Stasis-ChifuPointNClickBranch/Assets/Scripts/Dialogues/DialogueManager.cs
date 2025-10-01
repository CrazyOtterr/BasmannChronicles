using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public GameObject dialogueMenu;
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    
    public static bool isEnded = true;

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();    
    }

    public void StartDialogue (Dialogue dialogue, int index)
    {
        isEnded = false;
        dialogueMenu.SetActive(true);
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences[index].Text)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
        Invoke("DisplayNextSentence", 1f);
    }

    public void EndDialogue()
    {
        isEnded = true;
        dialogueMenu.SetActive(false);
        Debug.Log("End of conversation.");
    }
}
