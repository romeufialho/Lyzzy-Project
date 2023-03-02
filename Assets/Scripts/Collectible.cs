using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private Animator myAnimator;
    private const string collected = "collected";
    private bool isCollected = false;
    [SerializeField]
    private float feedbackTime = 3f;
    private Collider2D collectibleCollider = null;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        collectibleCollider = this.GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            collectibleCollider.enabled = false;
            isCollected = true;
            CollectedAnimation();
            GameManager.Instance.ShowFirstCollectedDialogue();
            Invoke(nameof(AddAndDestroy), feedbackTime);
        }
    }

    private void CollectedAnimation()
    {
        myAnimator.SetBool(collected, isCollected);
    }

    private void AddAndDestroy()
    {
        GameManager.Instance.AddCollectible(this);
        gameObject.SetActive(false);
    }
}
