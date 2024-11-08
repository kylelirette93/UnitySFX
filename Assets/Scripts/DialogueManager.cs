using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public string DialogueLines;
    public TextMeshProUGUI dialogueText;
    AudioSource dialogueAudio;
    public bool isTalking = false;
    public bool isSpeaking = false;

    Coroutine speakCoroutine;

    private void Start()
    {
        dialogueAudio = GetComponent<AudioSource>();
        dialogueText.text = "";
    }

    private void Update()
    {
        if (isTalking && !isSpeaking)
        {
            speakCoroutine = StartCoroutine(Speak());
        }
    }



    IEnumerator Speak()
    {
        isSpeaking = true;
        dialogueText.text = "";

        foreach (char c in DialogueLines)
        {
            dialogueAudio.enabled = true;
            dialogueText.text += c;
            yield return new WaitForSeconds(0.065f);
        }

        isTalking = false;
        isSpeaking = false;
        dialogueAudio.enabled = false;
    }

    public void StopDialogue()
    {
        if (speakCoroutine != null)
        {
            StopCoroutine(speakCoroutine);
        }
        isTalking = false;
        isSpeaking = false;
        dialogueText.text = "";  
        dialogueAudio.enabled = false;  
    }
}
