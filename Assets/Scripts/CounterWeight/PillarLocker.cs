using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarLocker : MonoBehaviour
{
    // Components
    private Rigidbody2D myRigidbody = null;
    [SerializeField]
    private PlatformOscilation platform = null;
    [SerializeField]
    private Vector2 lockPlatformVelocity;
    [SerializeField]
    private GameObject lockerLimit = null;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        lockPlatformVelocity = platform.GetVelocity();

        myRigidbody.velocity = new Vector2(lockPlatformVelocity.y, lockPlatformVelocity.x);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Limit"))
        {
            lockerLimit.SetActive(true);
        }
    }
}
