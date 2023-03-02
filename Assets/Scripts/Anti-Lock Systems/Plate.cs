using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    [SerializeField]
    private GameObject pillar = null;
    private PlatformBehaviour pillarScript = null;

    private void Awake()
    {
        pillarScript = pillar.GetComponent<PlatformBehaviour>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pillarScript.PlatePressed();
        }
    }
}
