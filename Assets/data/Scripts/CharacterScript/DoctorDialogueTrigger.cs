using UnityEngine;

public class DoctorDialogueTrigger : MonoBehaviour
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