using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehaviour : MonoBehaviour
{
    private GameObject playerGameObject;
    [SerializeField]
    private GameObject playerRespawnPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerGameObject = other.gameObject;

            playerGameObject.transform.position = playerRespawnPoint.transform.position;
        }
    }
}
