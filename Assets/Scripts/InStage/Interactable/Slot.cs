using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    //public GameObject occupyObj;

    //public virtual void OnTriggerEnter(Collider other)
    //{
    //    if (AbleToPlace(other.gameObject))
    //        OnPlace(other.gameObject);
    //}

    //public virtual bool AbleToPlace(GameObject go)
    //{
    //    if (go == null)
    //        return false;

    //    if (!(go.CompareTag("Ingrediant") || go.CompareTag("Cookware")))
    //        return false;

    //    if (occupyObj != null)
    //        return false;

    //    return true;
    //}

    //public virtual void OnPlace(GameObject go)
    //{
    //    occupyObj = go;

    //    Utils.FixPosition(occupyObj);

    //    Vector3 newPos = transform.position;
    //    newPos.y += transform.lossyScale.y * 0.5f + occupyObj.transform.lossyScale.y * 0.5f;
    //    occupyObj.transform.position = newPos;

    //    occupyObj.transform.SetParent(transform);

    //    Interactable interactable = occupyObj.GetComponent<Interactable>();
    //    if (interactable != null)
    //        interactable.enabled = false;
    //}

    //public virtual bool AbleToTakeOut(GameObject dest)
    //{
    //    return occupyObj != null;
    //}

    //public virtual GameObject OnTakeOut(GameObject dest)
    //{
    //    GameObject takeout = occupyObj;
    //    occupyObj = null;

    //    Utils.UnFixPosition(takeout);

    //    takeout.transform.parent = null;

    //    Interactable interactable = takeout.GetComponent<Interactable>();
    //    if (interactable != null)
    //        interactable.enabled = true;

    //    return takeout;
    //}
}
