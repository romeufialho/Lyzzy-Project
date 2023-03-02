using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    private InputSystem inputSystem = null;
    private bool dropTail = false;

    // References
    private GameObject platform = null;

    private void Awake()
    {
        inputSystem = new InputSystem();
    }

    void Start()
    {
        inputSystem.Enable();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            Debug.Log("TAIL COLLIDES WITH PLATFORM");
            this.platform = other.gameObject;
        }
    }

    void OnDestroy()
    {
        if (platform != null)
        {
            Platform platformScript = platform.GetComponent<Platform>();
            if (platformScript != null)
            {
                platformScript.RemoveTail();
            }
            PlatformOscilation platformOscilation = platform.GetComponent<PlatformOscilation>();
            if (platformOscilation != null)
            {
                platformOscilation.RemoveTail();
            }
        }
        else
        {
            print("TAIL NOT ON PLATFORM");
        }
    }
}
