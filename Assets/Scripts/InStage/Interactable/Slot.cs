using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public GameObject occupyObj;

    public virtual void OnTriggerEnter(Collider other)
    {
        if (!(other.CompareTag("Ingrediant") || other.CompareTag("Cookware")))
            return;
        OnPlace(other.gameObject);
    }

    public virtual void OnPlace(GameObject go)
    {
        if (!(go.CompareTag("Ingrediant") || go.CompareTag("Cookware")))
            return;

        if (occupyObj != null)
            return;

        occupyObj = go;

        Utils.FixPosition(occupyObj);

        Vector3 newPos = transform.position;
        newPos.y += transform.lossyScale.y * 0.5f + occupyObj.transform.lossyScale.y * 0.5f;
        occupyObj.transform.position = newPos;

        occupyObj.transform.SetParent(transform);

        Interactable interactable = occupyObj.GetComponent<Interactable>();
        if (interactable != null)
            interactable.enabled = false;
    }

    public virtual GameObject OnTakeOut()
    {
        if (occupyObj == null)
            return null;

        GameObject takeout = occupyObj;
        occupyObj = null;

        Utils.UnFixPosition(takeout);

        takeout.transform.parent = null;

        Interactable interactable = takeout.GetComponent<Interactable>();
        if (interactable != null)
            interactable.enabled = true;

        return takeout;
    }
}
