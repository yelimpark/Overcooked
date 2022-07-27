using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{    
    public Transform targetPosition;
    public Transform originPosition;

    private Transform origin;
    private Vector3 vel = Vector3.zero;

    private void Awake()
    {
        origin = this.gameObject.transform;
    }
    private void Update()
    {
        StartCoroutine(CoMapMove());
    }

    public IEnumerator CoMapMove()
    {

        yield return new WaitForSeconds(5f);
        transform.position = Vector3.SmoothDamp(gameObject.transform.position, targetPosition.transform.position, ref vel, 1f);
        //transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPosition.transform.position, 1f);

        yield return new WaitForSeconds(5f);
        transform.position = Vector3.SmoothDamp(gameObject.transform.position, origin.position, ref vel, 1f);
        //transform.position = Vector3.MoveTowards(gameObject.transform.position, origin.position, 1f);
    }
}
