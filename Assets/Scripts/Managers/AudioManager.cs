using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; } = null;
    
    [SerializeField]
    private AudioMixer audioMixer = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); //audiomanager might be put on main menu
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeMasterVolume(float volumeValue)
    {
        audioMixer.SetFloat("MasterVolume", volumeValue);
    }
}