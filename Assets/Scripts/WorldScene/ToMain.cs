using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToMain : MonoBehaviour
{
    private Animator animator;
    public bool onCollider = false;
    public AudioSource audioSource;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        audioSource.Play();
        onCollider = true;
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("isEnter", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        onCollider = false;
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("isEnter", false);
        }
    }
}
