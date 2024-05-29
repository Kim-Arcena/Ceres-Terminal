using System.Collections;
using UnityEngine;
using TMPro;

public class TypingEffect : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;

    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    void Update()
    {
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        if(gameObject.tag != "OneType"){
            yield return new WaitForSeconds(3.5f);
            StartCoroutine(UntypeLine());
        }
    }

    IEnumerator UntypeLine()
    {
        int charCount = textComponent.text.Length;

        for (int i = charCount - 1; i >= 0; i--)
        {
            textComponent.text = textComponent.text.Remove(i);
            yield return new WaitForSeconds(textSpeed);
        }

        gameObject.SetActive(false);
    }
}