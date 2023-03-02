using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitToTitle : MonoBehaviour
{
    public void ToTitle()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
