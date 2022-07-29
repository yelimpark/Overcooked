using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{    
    public Transform targetPos;
    public Transform originPos;
    public Transform desPos;

    public float speed = 5f;

    private void Start()
    {
        transform.position = originPos.position;
        desPos = targetPos;
        iTween.MoveTo(gameObject, iTween.Hash(
            "delay", 2f,
            "speed", 1,
            "position", desPos.position,
            "essettype", iTween.EaseType.easeOutQuart,
            "oncomplete", "SetDest"
        ));
    }
    public void SetDest()
    {
        if (targetPos == desPos)
        {
            desPos = originPos;
        }
        else
        {
            desPos = targetPos;
        }

        iTween.MoveTo(gameObject, iTween.Hash(
        "delay", 2f,
        "speed", 1,
        "position", desPos.position,
        "essettype", iTween.EaseType.easeOutQuart,
        "oncomplete", "SetDest"
        ));
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }
}
