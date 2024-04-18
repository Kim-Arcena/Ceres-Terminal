using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoIntroductionManager : MonoBehaviour
{
    [SerializeField] public Transform shipTransform;
    [SerializeField] public Vector3 endPosition = new Vector3(0f, 50.0f, -5f);

    private LevelTwoDialogueManager dialogueManager;
    public float speed = 5f;

    void Start()
    {
        dialogueManager = FindObjectOfType<LevelTwoDialogueManager>();
    }

    void Update()
    {
        if (dialogueManager.finishDialogue)
        {
            shipTransform.Translate((endPosition + shipTransform.position).normalized * speed * Time.deltaTime);

            if (Vector3.Distance(shipTransform.position, endPosition) < 0.1f)
            {
                shipTransform.position = endPosition;
            }
        }
    }
}
