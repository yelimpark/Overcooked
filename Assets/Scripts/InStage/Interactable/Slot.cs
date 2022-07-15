using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    protected GameObject occupyObj;
    public GameObject OccupyObj { get; protected set; }

    public void OnTriggerEnter(Collider other)
    {
        OnPlace(other.gameObject);
    }

    public virtual void OnPlace(GameObject go)
    {
        if (OccupyObj != null)
            return;

        OccupyObj = go;

        Utils.FixPosition(OccupyObj);

        Vector3 newPos = transform.position;
        newPos.y += transform.lossyScale.y * 0.5f + OccupyObj.transform.lossyScale.y * 0.5f;
        OccupyObj.transform.position = newPos;

        OccupyObj.transform.SetParent(transform);

        Interactable interactable = OccupyObj.GetComponent<Interactable>();
        if (interactable != null)
            interactable.enabled = false;
    }

    public virtual GameObject OnTakeOut()
    {
        if (OccupyObj == null)
            return null;

        GameObject takeout = OccupyObj;
        OccupyObj = null;

        Utils.UnFixPosition(takeout);

        takeout.transform.parent = null;

        Interactable interactable = takeout.GetComponent<Interactable>();
        if (interactable != null)
            interactable.enabled = true;

        return takeout;
    }
}
