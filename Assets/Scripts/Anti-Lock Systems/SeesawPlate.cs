using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeesawPlate : MonoBehaviour
{
    [SerializeField]
    private GameObject weightSpawn = null;
    private Transform weightSpawnTransform = null;
    [SerializeField]
    private GameObject weightPrefab = null;
    [SerializeField]
    private GameObject seesawLocker = null;
    private Collider2D seesawLockerCollider = null;

    private void Awake()
    {
        weightSpawnTransform = weightSpawn.GetComponent<Transform>();
        if (seesawLocker != null)
        {
            seesawLockerCollider = seesawLocker.GetComponent<Collider2D>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            InstantiateWeight();
            if (seesawLocker != null)
            {
                DisableSeesawCollider();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (seesawLocker != null)
            {
                EnableSeesawCollider();
            }
        }
    }

    private void EnableSeesawCollider()
    {
        seesawLockerCollider.enabled = true;
    }

    private void DisableSeesawCollider()
    {
        seesawLockerCollider.enabled = false;
    }
    
    private void InstantiateWeight()
    {
        Instantiate(weightPrefab, weightSpawnTransform.position, weightSpawnTransform.rotation);
    }
}
