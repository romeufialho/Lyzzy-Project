using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField]
    private GameObject firstCollectionDialogue = null;
    [SerializeField]
    private TextMeshProUGUI textSaved = null;
    [SerializeField]
    private TextMeshProUGUI textMissing = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowFirstCollectedDialogue()
    {
        firstCollectionDialogue.SetActive(true);
        Invoke(nameof(HideFirstCollectedDialogue), 5f);
    }

    public void HideFirstCollectedDialogue()
    {
        firstCollectionDialogue.SetActive(false);
    }

    public void ShowCollectiblesStatus()
    {
        textSaved.text = GameManager.Instance.GetCollected().ToString();
        textMissing.text = GameManager.Instance.GetMissing().ToString();
    }
}
