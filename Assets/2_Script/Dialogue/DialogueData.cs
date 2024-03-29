using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueData : MonoSingleton<DialogueData>
{
    [SerializeField]
    private GameObject dialoguePanel = null;
    [SerializeField]
    private DialogueGroup dialogueGroup = null;
    public DialogueGroup CurrentDialogueGroup { get { return dialogueGroup; } }
    public Text nameText;
    public Text dialogueText;
    private Queue<string> sentences;
    private bool watiTyping = false;
    void Start()
    {
        sentences = new Queue<string>();
    }
    public void StartDialogue(int id)
    {
        dialogueGroup.id = id;
        dialoguePanel.SetActive(true);
        Debug.Log("Starting conversation with " + dialogueGroup.dialogueList[dialogueGroup.id].name);

        nameText.text = dialogueGroup.dialogueList[dialogueGroup.id].name;

        sentences.Clear();
        foreach (string sentence in dialogueGroup.dialogueList[dialogueGroup.id].sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (watiTyping) return;
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StartCoroutine(TypeSentence(sentence));
    }
    private IEnumerator TypeSentence(string sentence)
    {
        watiTyping = true;
        dialogueText.text = "";
        foreach (char latter in sentence.ToCharArray())
        {
            dialogueText.text += latter;
            yield return new WaitForSeconds(0.05f);
        }
        watiTyping = false;
    }
    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        Debug.Log("End of conversation");
    }
}
