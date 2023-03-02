using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TailCooldown : MonoBehaviour
{
    private const string tailIsAttached = "hasTail";
    private float energyPoints = 100f;
    private float maxEnergy = 100f;
    [SerializeField]
    protected Image energyBar = null;
    private Animator myAnimator = null;
    private bool isDropable = true;
    [SerializeField]
    private float recoverPoints = 2f;
    private PlayerBehaviour player = null;

    // Tail
    [Header("Tail Components")]
    [SerializeField]
    private GameObject tailPrefab = null;
    [SerializeField]
    private Transform tailSpawn = null;
    [SerializeField]
    private float tailRespawnDelay = 5f;
    private GameObject tail = null;

    [Header("Inputs")]
    private InputSystem inputSystem = null;
    private bool dropTail = false;


    private void Awake()
    {
        inputSystem = new InputSystem();

        myAnimator = GetComponent<Animator>();
        player = GetComponent<PlayerBehaviour>();
    }

    private void Start()
    {
        inputSystem.Enable();
    }

    private void Update()
    {
        dropTail = inputSystem.player.droptail.triggered;
        if (dropTail)
        {
            if (energyPoints == 100f)
            {
                DropTail();
            }
        }

        if (energyPoints < maxEnergy) // energy regen 
        {
            energyPoints += recoverPoints * Time.deltaTime;
            energyPoints = Mathf.Clamp(energyPoints, 0f, maxEnergy); //life cap min and max
            energyBar.fillAmount = energyPoints / maxEnergy;

            myAnimator.SetBool(tailIsAttached, false);
            isDropable = false;
        }
        else
        {
            isDropable = true;
            myAnimator.SetBool(tailIsAttached, true);

            if (tail != null)
            {
                Destroy(tail);
            }
        }
    }
    public void DropTail()
    {
        if (tail != null)
        {
            Destroy(tail);
        }

        tail = Instantiate(tailPrefab, tailSpawn.transform.position, gameObject.transform.rotation);

        energyPoints = 0;
        energyPoints = Mathf.Clamp(energyPoints, 0, maxEnergy);
        energyBar.fillAmount = energyPoints / maxEnergy;

        isDropable = false;

        // this is only for testing purposes, make tail destroy when energy == 100
        // Destroy(tail, tailRespawnDelay);
    }
}
