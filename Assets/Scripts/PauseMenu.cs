using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu = null;
    [SerializeField]
    private GameObject optionsMenu = null;
    [SerializeField]
    private GameObject volumeMenu = null;
    [SerializeField]
    private GameObject controlsMenu = null;
    private InputSystem inputActions = null;
    private bool pause = false;
    private bool isPaused = false;

    private void Start()
    {
        inputActions = new InputSystem();
        inputActions.Enable();

        if (!pause)
        {
            pause = inputActions.player.pause.triggered;
        }
    }

    private void Update()
    {
        pause = inputActions.player.pause.triggered;

        if (pause)
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

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        volumeMenu.SetActive(false);
        controlsMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    private void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public bool IsPaused()
    {
        return isPaused;
    }
}
