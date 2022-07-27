using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SinglePlay : MonoBehaviour
{
    public InputHandler ih;
    private Image active;
    private Rigidbody rb;
    private Animator animator;

    private void Awake()
    {
        ih = GetComponent<InputHandler>();
        active = GetComponentInChildren<Image>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        rb.velocity = Vector3.zero;
        animator.SetBool("isWalking", false);
        ih.enabled = !ih.enabled;
        active.gameObject.SetActive(ih.enabled);
    }
}
