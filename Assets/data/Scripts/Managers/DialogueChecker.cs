using UnityEngine;

namespace data.Scripts.Managers
{
    public class DialogueChecker : MonoBehaviour
    {
        public static DialogueChecker Instance;

        public TextAsset storyModeDialogue;
        
        public bool chicaGuayTalked = false;

        public bool yasuhiroTalked = false;

        public bool zagreusTalked = false;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void setFlagTrue(string flag)
        {
            switch (flag)
            {
                case "chicaGuayTalked":
                    chicaGuayTalked = true;
                    break;
                case "yasuhiroTalked":
                    yasuhiroTalked = true;
                    break;
                case "zagreusTalked":
                    zagreusTalked = true;
                    break;
            }
            CheckFlags();
        }
        private void CheckFlags()
        {
            if (chicaGuayTalked && yasuhiroTalked && zagreusTalked)
            {
                DialogueManager.Instance.ExitDialogueMode();
                DialogueManager.Instance.EnterDialogueMode(storyModeDialogue);
            }
        }
    }
}