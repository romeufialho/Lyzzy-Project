using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeesawLocker : MonoBehaviour
{
    private Rigidbody2D myRigidbody = null;

    [SerializeField]
    private GameObject platform = null;
    private PlatformOscilation platformScript = null;

    [SerializeField]
    private GameObject lockerLimit = null;

    [SerializeField]
    private GameObject platformOscilation = null;
    private PlatformOscilation platformOscilationScript = null;

    private Vector2 lockPlatformVelocity;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        platformScript = platform.GetComponent<PlatformOscilation>();

        platformOscilationScript = platformOscilation.GetComponent<PlatformOscilation>();
    }

    private void FixedUpdate()
    {
        lockPlatformVelocity = platformScript.GetVelocity();

        myRigidbody.velocity = new Vector2(-lockPlatformVelocity.y, lockPlatformVelocity.x);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Limit"))
        {
            lockerLimit.SetActive(true);
        }
    }
}
