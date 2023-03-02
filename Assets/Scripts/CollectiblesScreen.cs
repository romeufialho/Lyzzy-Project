using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject collectiblesScreen;

    private bool collectibles = false;
    private bool isPaused = false;

    private InputSystem inputActions = null;

    [SerializeField]
    private List<GameObject> lizardList = new List<GameObject>();

    private void Start()
    {
        inputActions = new InputSystem();
        inputActions.Enable();

        if (!collectibles)
        {
            collectibles = inputActions.player.collectibles.triggered;
        }

        GameManager.Instance.SetUICollectibles(lizardList);
    }

    private void Update()
    {
       collectibles = inputActions.player.collectibles.triggered;

        if (collectibles)
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
        collectiblesScreen.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    private void PauseGame()
    {
        collectiblesScreen.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public bool IsPaused()
    {
        return isPaused;
    }
}
