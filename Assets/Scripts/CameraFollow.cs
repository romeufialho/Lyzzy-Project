using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private Transform playerTransform;
    [SerializeField]
    private float smoothTime = 0.5f;
    [SerializeField]
    private float offsetY = 3f;
    [SerializeField]
    private float offsetX = 3f;

    private float initialZ;

    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        initialZ = transform.position.z;
        playerTransform = player.transform;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = playerTransform.position;
        targetPosition.x += offsetX;
        targetPosition.y += offsetY;
        targetPosition.z = initialZ;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
