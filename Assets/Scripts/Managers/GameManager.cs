using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField]
    private List<Collectible> collectiblesList = new List<Collectible>();
    [SerializeField]
    private List<GameObject> lizardList = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UICollectiblesCheckUp();
    }

    public void AddCollectible(Collectible collectible)
    {
        collectiblesList.Add(collectible);
        UpdateCollectiblesUI();
    }

    public void UpdateCollectiblesUI()
    {
        Debug.Log(collectiblesList.Count + "collected lizards");
        switch (collectiblesList.Count)
        {
            case 1:
                Debug.Log(lizardList[0].gameObject.name + " activated");
                lizardList[0].gameObject.SetActive(true);
                break;
            case 2:
                Debug.Log(lizardList[1].gameObject.name + " activated");
                lizardList[1].gameObject.SetActive(true);
                break;
            case 3:
                Debug.Log(lizardList[2].gameObject.name + " activated");
                lizardList[2].gameObject.SetActive(true);
                break;
            case 4:
                Debug.Log(lizardList[3].gameObject.name + " activated");
                lizardList[3].gameObject.SetActive(true);
                break;
            case 5:
                Debug.Log(lizardList[4].gameObject.name + " activated");
                lizardList[4].gameObject.SetActive(true);
                break;
            case 6:
                Debug.Log(lizardList[5].gameObject.name + " activated");
                lizardList[5].gameObject.SetActive(true);
                break;
            case 7:
                Debug.Log(lizardList[6].gameObject.name + " activated");
                lizardList[6].gameObject.SetActive(true);
                break;
            case 8:
                Debug.Log(lizardList[7].gameObject.name + " activated");
                lizardList[7].gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void ShowFirstCollectedDialogue()
    {
        if (collectiblesList.Count == 0)
        {
            UIManager.Instance.ShowFirstCollectedDialogue();
        }
    }

    public int GetCollected()
    {
        return collectiblesList.Count;
    }

    public int GetMissing()
    {
        return lizardList.Count - collectiblesList.Count;
    }

    public void ResetCollected()
    {
        collectiblesList.Clear();
    }

    public void ResetUICollected()
    {
        lizardList.Clear();
    }

    public void SetUICollectibles(List<GameObject> list)
    {
        lizardList = list;
    }

    private void UICollectiblesCheckUp()
    {
        for (int i = 0; i < lizardList.Count; i++)
        {
            if (lizardList[i] == null)
            {
                lizardList.Remove(lizardList[i]);
            }
        }
    }
}
