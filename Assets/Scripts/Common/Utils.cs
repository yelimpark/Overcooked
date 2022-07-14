using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    LEFT,
    RIGHT,
    UP,
    DOWN,
}

public class Utils : MonoBehaviour
{
    public static readonly float RAY_MAX_LENGTH = 10f;

    public static void FixPosition(GameObject go)
    {
        Rigidbody rb = go.GetComponent<Rigidbody>();
        if (rb != null)
            rb.isKinematic = true;
            //rb.constraints = RigidbodyConstraints.FreezeAll;

        Collider collider = go.GetComponent<Collider>();
        if (collider != null)
            collider.enabled = false;

        go.transform.rotation = Quaternion.identity;
    }

    public static void UnFixPosition(GameObject go)
    {
        Rigidbody rb = go.GetComponent<Rigidbody>();
        if (rb != null)
            rb.isKinematic = false;
        //rb.constraints = RigidbodyConstraints.None;

        var colliders = go.transform.GetComponentsInChildren<Collider>();
        foreach (var childCollider in colliders)
        {
            childCollider.enabled = true;
        }
    }

    public static bool IsFalling(GameObject go, float errorRange, LayerMask target)
    {
        RaycastHit hit;
        Physics.Raycast(go.transform.position, Vector3.down, out hit, RAY_MAX_LENGTH, target);

        if (Vector3.Distance(hit.transform.position, go.transform.position) > errorRange + go.transform.lossyScale.y)
        {
            return false;
        }

        return true;
    }
}
