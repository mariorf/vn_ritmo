using System;
using System.Collections;
using System.Collections.Generic;
using data.Scripts.Managers;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    //Singleton
    public static DialogueManager Instance;
    
    
    [Header("UI")]
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI characterName;
    public SceneTransitionWithAnimation sceneTransition;
    
    [Header("Animation")]
    public Animator portraitAnimator;

    
    [Header("Dialogue")]
    private Story currentStory;
    public bool isDialoguePlaying;

    
    [Header("Tags")]
    private const string SPEAKER_TAG = "speaker";
    private const string SPRITE_TAG = "sprite";
    private const string SFX_TAG = "sfx";
    private const string SCENE_TAG = "scene";
    private const string FLAG_TAG = "flag";

    private void Start()
    {
        isDialoguePlaying = false;
        dialoguePanel.SetActive(false);
    }

    private void Update()
    {
        //Update only plays if the dialogue is playing
        if (!isDialoguePlaying)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0) && !PauseManager.Instance.isPaused)
        {
            ContinueStory();
        }
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
    }
    
    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            
            SoundEffectsManager.Instance.PlaySFX("pass_dialogue");

            HandleTags(currentStory.currentTags);
        }
        else
        {
            ExitDialogueMode();
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            
            //PARSE DEL TAG EN EL VALOR CLAVE
            string[] splitTag = tag.Split(':');
            //Esto devolvera un array vcon 2 valores tag y valor 
            

            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            
            switch (tagKey)
            {
                case SPEAKER_TAG:
                    characterName.text = tagValue;
                    break;
                
                case SPRITE_TAG:
                    portraitAnimator.Play(tagValue);
                    break;
                
                case SFX_TAG:
                    SoundEffectsManager.Instance.PlaySFX(tagValue);
                    break;
                
                case SCENE_TAG:
                    sceneTransition.LoadScene();
                    break;
                
                case FLAG_TAG:
                    DialogueChecker.Instance.setFlagTrue(tagValue);
                    break;
            }
        }
    }
    
    
    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        isDialoguePlaying = true;
        dialoguePanel.SetActive(true);
        SpriteManager.getInstance().setAllVisible(false);
    }
    public void ExitDialogueMode()
    {
        isDialoguePlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        SpriteManager.Instance.setAllVisible(true);
    }
}
