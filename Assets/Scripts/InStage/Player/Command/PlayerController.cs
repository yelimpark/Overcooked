using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum AxisType
    {
        X,
        Y,
        Z,
    }

    private Rigidbody rb;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    public void SetVelocity(AxisType type, float value)
    {
        Vector3 newVelocity = rb.velocity;
        switch(type)
        {
            case AxisType.X:
                newVelocity.x = value;
                break;
            case AxisType.Y:
                newVelocity.y = value;
                break;
            case AxisType.Z:
                newVelocity.z = value;
                break;
        }
        rb.velocity = newVelocity;
    }

    public void SetAnimationBool(string parameter, bool value)
    {
        animator.SetBool(parameter, value);
    }
}
