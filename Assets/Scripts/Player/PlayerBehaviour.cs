using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    // Animation Parameters
    private const string animParameterHorizontalSpeed = "horizontalSpeed";
    private const string animParameterVerticalSpeed = "verticalSpeed";

    [Header("Movement")]
    [SerializeField]
    private float walkingSpeed = 2.5f;

    [Header("Jump")]
    [SerializeField]
    private float jumpForce = 350f;
    private float originalGravityScale;
    [SerializeField]
    private float fallGravityScale;
    [SerializeField]
    private Transform[] feetTransform = new Transform[2];
    [SerializeField]
    private LayerMask groundLayerMask = 0;

    [Header("Components")]
    private Rigidbody2D myRigidbody = null;
    private Animator myAnimator = null;

    [Header("Inputs")]
    private InputSystem inputSystem = null;
    private float movementDirection = 0f;
    private bool jump = false;
    private bool dropTail = false;

    [Header("States")]
    private bool onGround = false;
    private Collider2D[] groundCheclColliders = new Collider2D[1];

    private TailCooldown tailCooldownScript = null;

    [SerializeField]
    private PauseMenu pauseMenuObj = null;
    private PauseMenu pauseMenu = null;
    [SerializeField]
    private CollectiblesScreen collectiblesScreenObj = null;
    private CollectiblesScreen collectiblesScreen = null;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        tailCooldownScript = GetComponent<TailCooldown>();

        inputSystem = new InputSystem();

        pauseMenu = pauseMenuObj.GetComponent<PauseMenu>();
        collectiblesScreen = collectiblesScreenObj.GetComponent<CollectiblesScreen>();
    }

    void Start()
    {
        inputSystem.Enable();
        originalGravityScale = myRigidbody.gravityScale;
    }

    void Update()
    {
        if (!pauseMenu.IsPaused() && !collectiblesScreen.IsPaused())
        {
            movementDirection = inputSystem.player.movement.ReadValue<float>();

            if (CheckDirectionChange())
            {
                FlipHorizontaly();
            }

            myRigidbody.velocity = new Vector2(movementDirection * walkingSpeed, myRigidbody.velocity.y);
            myAnimator.SetFloat(animParameterHorizontalSpeed, Mathf.Abs(myRigidbody.velocity.x));
            myAnimator.SetFloat(animParameterVerticalSpeed, myRigidbody.velocity.y);

            if (!jump)
            {
                jump = inputSystem.player.jump.triggered;
            }
        }
    }

    private void FixedUpdate()
    {
        onGround = CheckForGround();

        myAnimator.SetBool("isGrounded", onGround);

        if (onGround)
        {
            myRigidbody.gravityScale = originalGravityScale;

            if (jump)
            {
                Jump();
            }
        }
        else if (myRigidbody.velocity.y < 2f)
        {
            myRigidbody.gravityScale = fallGravityScale;
        }// gravityScale returns to normal when player hits ground

        jump = false; //reset input
    }

    private void OnDisable()
    {
        inputSystem.Disable();
    }

    private bool CheckDirectionChange()
    {
        return transform.right.x * movementDirection < 0;
    }

    private void FlipHorizontaly()
    {
        Vector3 targetRotation = transform.localEulerAngles;
        targetRotation.y += 180f;
        transform.localEulerAngles = targetRotation;
    }

    private bool CheckForGround()
    {
        for (int i = 0; i < feetTransform.Length; i++)
        {
            if (Physics2D.OverlapPointNonAlloc(feetTransform[i].position,
            groundCheclColliders,
            groundLayerMask) > 0)
            {
                return true;
            }
        }
        return false;
    }

    private void Jump()
    {
        Debug.Log("Jumping");

        myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
        myRigidbody.AddForce(Vector2.up * jumpForce);
    }
}