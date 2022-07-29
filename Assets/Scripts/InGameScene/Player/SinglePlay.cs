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
    //private VirtualJoyStick joystick;

    private void Awake()
    {
        ih = GetComponent<InputHandler>();
        active = GetComponentInChildren<Image>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        //joystick = GetComponentInChildren<VirtualJoyStick>();
    }

    void Update()
    {
#if UNITY_STANDALONE
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Toggle();
        }
#endif
    }
#if UNITY_ANDROID
    public void GetChangeButtonDown()
    {
        Toggle();
    }
#endif

    public void Toggle()
    {
        rb.velocity = Vector3.zero;
        animator.SetBool("isWalking", false);
        ih.enabled = !ih.enabled;
        active.gameObject.SetActive(ih.enabled);
    }
}
