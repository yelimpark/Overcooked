using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    private GameObject occupyObj;
    public GameObject OccupyObj { get; private set; }

    public void OnTriggerEnter(Collider other)
    {
        OnPlace(other.gameObject);
    }

    public void OnPlace(GameObject go)
    {
        if (!go.CompareTag("Ingrediant") || OccupyObj != null)
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

        CookingBehaviour cb = OccupyObj.GetComponent<CookingBehaviour>();
        if (cb != null)
            cb.CheckPosition();
    }

    public GameObject OnTakeOut()
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