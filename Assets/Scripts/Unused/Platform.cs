using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private GameObject platform1 = null;

    [SerializeField]
    private GameObject platform2 = null;
    private Platform platform1Script = null;
    private Platform platform2Script = null;


    // Platform content
    [SerializeField]
    private bool hasTail = false;
    [SerializeField]
    private bool hasPlayer = false;

    [SerializeField]
    private float maxPlatformReach = 2f;

    private float platInitialY = 0;

    private bool stopVertical = false;
    [SerializeField]
    private bool isOnTopLimit = false;
    [SerializeField]
    private bool isStuck = false;

    // Components
    private Rigidbody2D myRigidbody = null;

    // Components from other Platforms
    private Rigidbody2D platform1Rigidbody = null;
    private Rigidbody2D platform2Rigidbody = null;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        platform2Rigidbody = platform2.GetComponent<Rigidbody2D>();
        platform1Rigidbody = platform1.GetComponent<Rigidbody2D>();

        platform1Script = platform1.GetComponent<Platform>();
        platform2Script = platform2.GetComponent<Platform>();
    }

    private void FixedUpdate()
    {
        this.isStuck = hasTail || isOnTopLimit;

        if (stopVertical)
        {
            myRigidbody.bodyType = RigidbodyType2D.Static;
        }
        else
        {
            myRigidbody.bodyType = RigidbodyType2D.Dynamic;
        }

        // other platforms movement
        if (hasPlayer && !platform1Script.HasTail())
        {
            platform1Rigidbody.velocity = -(myRigidbody.velocity);
        }
        if (hasPlayer && !platform2Script.HasTail())
        {
            platform2Rigidbody.velocity = -(myRigidbody.velocity);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // this.stopVertical = false;
            // platform1.UnlockPlatform();
            // platform2.UnlockPlatform();
            // platInitialY = transform.position.y;

            if (platform1Script.IsStuck() && platform2Script.IsStuck())
            {
                this.stopVertical = true;
            }
            else
            {
                this.stopVertical = false;
                platform1Script.UnlockPlatform();
                platform2Script.UnlockPlatform();
                platInitialY = transform.position.y;
            }
        }

        if (other.CompareTag("Limit"))
        {
            isOnTopLimit = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Tail"))
        {
            //says if has tail
            hasTail = true;
            this.stopVertical = true;
        }

        if (other.CompareTag("Player"))
        {
            hasPlayer = true;

            // if (HasTail() == false)
            // {
                if (transform.position.y <= platInitialY - maxPlatformReach)
                {
                    this.stopVertical = true;
                }
            // }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hasPlayer = false;
        }

        if (other.CompareTag("Tail"))
        {
            hasTail = false;
        }

        if (other.CompareTag("Limit"))
        {
            isOnTopLimit = false;
            Debug.Log("Exit top limit");
        }
    }

    public bool HasTail()
    {
        return hasTail;
    }

    public void UnlockPlatform()
    {
        stopVertical = false;
    }

    public bool IsOnTopLimit()
    {
        return isOnTopLimit;
    }

    public bool IsStuck()
    {
        //Debug.Log("Has tail: " + hasTail);
        //Debug.Log("Is on top : " + isOnTopLimit);
        return isStuck;
    }

    public void RemoveTail()
    {
        hasTail = false;
    }
}
