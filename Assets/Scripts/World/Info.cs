using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour
{
    public Animator animator;
    public bool onCollider = false;

    public SceneDefinition sceneDefinition;

    private void OnTriggerEnter(Collider other)
    {
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

