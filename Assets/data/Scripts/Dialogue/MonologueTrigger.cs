using UnityEngine;

public class MonologueTrigger : MonoBehaviour
{
    public TextAsset monologue;

    private void Start()
    {
        if (DialogueManager.Instance != null && monologue != null)
        {
            DialogueManager.Instance.EnterDialogueMode(monologue);
        }
    }
}