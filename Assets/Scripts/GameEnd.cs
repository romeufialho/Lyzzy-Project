using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.Instance.ShowCollectiblesStatus();
            Invoke(nameof(LoadMainMenu), 5f);
            GameManager.Instance.ResetCollected();
            GameManager.Instance.ResetUICollected();
        }
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
