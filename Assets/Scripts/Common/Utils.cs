using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    public static readonly float RAY_MAX_LENGTH = 10f;

    public static void FixPosition(GameObject go)
    {
        Rigidbody rb = go.GetComponent<Rigidbody>();
        if (rb != null)
            rb.isKinematic = true;

        var colliders = go.GetComponents<Collider>();
        foreach(Collider collider in colliders)
        {
            collider.enabled = false;
        }

        go.transform.rotation = Quaternion.identity;
    }

    public static void UnFixPosition(GameObject go)
    {
        Rigidbody rb = go.GetComponent<Rigidbody>();
        if (rb != null)
            rb.isKinematic = false;

        var colliders = go.GetComponents<Collider>();
        foreach (Collider collider in colliders)
        {
            collider.enabled = true;
        }
    }

    public static bool IsFalling(GameObject go, float errorRange)
    {
        RaycastHit hit;
        Physics.Raycast(go.transform.position, Vector3.down, out hit, RAY_MAX_LENGTH, LayerMask.GetMask("Ground"));

        go.transform.rotation = Quaternion.identity;

        if (go.transform.position.y - hit.transform.position.y > errorRange + go.transform.lossyScale.y)
        {
            return false;
        }

        return true;
    }
}
