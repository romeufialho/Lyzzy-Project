using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PLATFORM
public class PlatformOscilation : MonoBehaviour
{
    // Components
    private Rigidbody2D myRigidbody = null;
    // content
    [SerializeField]
    private bool hasTail = false;
    [SerializeField]
    private bool hasPlayer = false;
    // states
    private bool affectsPillar;
    private bool affectsLocker = false;
    // limits
    [SerializeField]
    private GameObject lockerLimit;
    [SerializeField]
    private bool isOnLimit = true;
    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        affectsPillar = hasPlayer || hasTail;
    }

    public Vector2 GetVelocity()
    {
        return myRigidbody.velocity;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hasPlayer = true;
            if (lockerLimit != null)
                lockerLimit.SetActive(false);
        }
        if (other.CompareTag("Tail"))
        {
            if (lockerLimit != null)
                lockerLimit.SetActive(false);
            hasTail = true;
        }
        if (other.CompareTag("Limit"))
        {
            isOnLimit = true;
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
            isOnLimit = false;
        }
    }

    public void RemoveTail()
    {
        hasTail = false;
    }

    public bool AffectsPillar()
    {
        return affectsPillar;
    }

    public bool AffectsLocker()
    {
        return affectsLocker;
    }

    public bool IsOnlimit()
    {
        return isOnLimit;
    }
}
