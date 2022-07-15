using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("isEnter", true);
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("isEnter", false);
    }
}
