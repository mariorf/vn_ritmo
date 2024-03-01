using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndingManager : MonoBehaviour
{
    public GameObject ui;
    
    public GameObject uiEndGame;

    public GameObject sprites;

    public GameObject scenary;

    public static GameEndingManager Instance;

    public HighScores highScores;
    public void startGameEnd()
    {
        scenary.SetActive(false);
        ui.SetActive(false);
        uiEndGame.SetActive(true);
        sprites.SetActive(true);
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
