using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public TextAsset inkJSON;

    private void OnMouseDown()
    {
        if (!PauseManager.Instance.isPaused)
        {
            DialogueManager.Instance.EnterDialogueMode(inkJSON);
        }
    }
}