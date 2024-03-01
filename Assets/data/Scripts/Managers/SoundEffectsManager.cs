using UnityEngine;

public class SoundEffectsManager : MonoBehaviour
{
    public SoundEffectsGeneral soundEffectsGeneral;

    public static SoundEffectsManager Instance;

    public AudioSource audioSource;
    public void PlaySFX(string name)
    {
        foreach (AudioClip audioClip in soundEffectsGeneral.soundEffects)
        {
            if (audioClip.name == name)
            {
                audioSource.PlayOneShot(audioClip);
                return;
            }
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
}