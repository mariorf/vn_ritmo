using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public TextMeshProUGUI comboText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI missesText;

    private static int combo;
    private static int score;
    private static int missCount;

    private static int scoreMultiplier = 1;

    public Animator animator;

    public string[] animationNamesArray;
    public string[] animationsMissArray;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
        
        combo = 0;
        missCount = 0;
    }
    private void Update()
    {
        scoreText.text = "Score: " + score.ToString();
        comboText.text = combo.ToString();
        missesText.text = missCount.ToString();
    }

    public static void Hit()
    {
        SoundEffectsManager.Instance.PlaySFX("arc");

        score += 20 * scoreMultiplier;
        combo += 1;
        CheckComboScore();
    }

    public static void Miss()
    {
        combo = 0;
        missCount++;
        CheckComboScore();
        Instance.PlayRandomMissAnimation();
    }

    private static void CheckComboScore()
    {
        if (combo % 20 == 0 && combo > 0)
        {
            if (scoreMultiplier < 4)
            {
                scoreMultiplier += 1;
            }
            score += 100;
            Instance.PlayRandomAnimation();
        }
    }

    private void PlayRandomAnimation()
    {
        int randomIndex = Random.Range(0, animationNamesArray.Length);
        string randomAnimation = animationNamesArray[randomIndex];
        animator.Play(randomAnimation);
    }

    private void PlayRandomMissAnimation()
    {
        int randomIndex = Random.Range(0, animationsMissArray.Length);
        string randomAnimation = animationsMissArray[randomIndex];
        animator.Play(randomAnimation);
    }
    
    public int GetScore()
    {
        return score;
    }
}