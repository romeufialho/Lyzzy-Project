using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerLimit : MonoBehaviour
{
    [SerializeField]
    private GameObject platform = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        platform.SetActive(true);
    }
}
