using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PILLAR
public class PlatformBehaviour : MonoBehaviour
{
    // Components
    private Rigidbody2D myRigidbody = null;
    [SerializeField]
    private GameObject platform;
    private PlatformOscilation platformScript = null;
    private Vector2 platformVelocity;
    private bool platePressed = false;
    [SerializeField]
    private GameObject respawnPoint = null;
    private GameObject playerObj = null;
    // configs
    [SerializeField]
    private float pillarSpeed = 5f;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        platformScript = platform.GetComponent<PlatformOscilation>();
    }

    void FixedUpdate()
    {
        if (!platePressed)
        {
            if (platformScript.AffectsPillar())
            {
                myRigidbody.gravityScale = 0;

                platformVelocity = platformScript.GetVelocity();

                myRigidbody.velocity = -platformVelocity * pillarSpeed;
            }
            else
            {
                myRigidbody.gravityScale = 5f;
            }
        }
        else if (myRigidbody.bodyType != RigidbodyType2D.Static)
        {
            myRigidbody.velocity = Vector2.up * pillarSpeed;
            Invoke(nameof(StopMoving), 4f);
        }
    }

    public void PlatePressed()
    {
        platePressed = true;
    }

    private void StopMoving()
    {
        myRigidbody.velocity = Vector2.zero;
        myRigidbody.bodyType = RigidbodyType2D.Static;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerObj = other.gameObject;
            Vector2 playerVelocity = playerObj.GetComponent<Rigidbody2D>().velocity;
            //if player speed vertical != 0 gets squashed by wall
            if (playerVelocity.y > -0.2 && playerVelocity.y < 0.2)
            {
                playerObj.transform.position = respawnPoint.transform.position;
            }
        }
    }
}
