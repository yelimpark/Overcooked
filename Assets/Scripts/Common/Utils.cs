using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    public static readonly float RAY_MAX_LENGTH = 10f;

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
