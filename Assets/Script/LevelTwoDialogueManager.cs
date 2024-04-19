using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTwoDialogueManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text dialogueText;
    private string[] dialogueLines;
    private int currentLine = 0;
    public bool finishDialogue = false;

    void Start()
    {
        dialogueLines = LoadDialogue();
        DisplayNextLine();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextLine();
        }
    }

    void DisplayNextLine()
    {
        if (currentLine < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLine];
            currentLine++;
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        finishDialogue = true;
        gameObject.SetActive(false);
    }

    string[] LoadDialogue()
    {
        return new string[]
        {
            "Wait, is it what I think it is?",
            "Is this... home?"
        };
    }
}
