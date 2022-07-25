using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{    
    public Transform targetPosition;
    public Transform originPosition;

    private Vector3 vel = Vector3.zero;
    private void Update()
    {
        StartCoroutine(CoMapMove());
    }

    public IEnumerator CoMapMove()
    {

        yield return new WaitForSeconds(5f);
        transform.position = Vector3.SmoothDamp(gameObject.transform.position, targetPosition.transform.position, ref vel, 1f);
        Debug.Log(transform.position);

        yield return new WaitForSeconds(5f);
        transform.position = Vector3.SmoothDamp(gameObject.transform.position, originPosition.transform.position, ref vel, 1f);
        Debug.Log(transform.position);

    }
}
