using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    public DialogueManager manager;
    public GameObject dialoguePanel;

    private void OnTriggerEnter(Collider other)
    {
        dialoguePanel.SetActive(true);
        manager.isTalking = true;
    }
    private void OnTriggerExit(Collider other)
    {
        dialoguePanel.SetActive(false);
        manager.StopDialogue();
    }
}
