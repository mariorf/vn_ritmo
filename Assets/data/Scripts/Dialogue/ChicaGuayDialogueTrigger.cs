using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChicaGuayDialogueTrigger : MonoBehaviour
{
    public TextAsset StartingDialogue;

    private void OnMouseDown()
    {
        if (!PauseManager.Instance.isPaused)
        {
            DialogueManager.Instance.EnterDialogueMode(StartingDialogue);
        }
    }
}
