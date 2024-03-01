using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance;
    
    public GameObject pauseMenu;

    public GameObject textCanvas;

    public KeyCode pauseKey;

    public bool isPaused;

    public bool isTextCanvasActive;
    
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
    
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        //If text canvas is active deactivate it and set bool to true
        if (textCanvas.activeSelf)
        {
            isTextCanvasActive = true;
            textCanvas.SetActive(false);
        }
        
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        // If text canvas was active before pausing, reactivate it
        if (isTextCanvasActive)
        {
            textCanvas.SetActive(true);
            isTextCanvasActive = false; // Reset the flag
        }
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

}
