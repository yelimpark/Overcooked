using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableLocation : MonoBehaviour
{
    private GameObject OccupyObj;

    public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Ingrediant") || OccupyObj != null)
            return;

        OccupyObj = other.gameObject;

        // position correction
        Vector3 newPos = transform.position;
        newPos.y += transform.localScale.y;
        OccupyObj.transform.position = newPos;

        Rigidbody rb = OccupyObj.GetComponent<Rigidbody>();
        if (rb != null)
            rb.constraints = RigidbodyConstraints.FreezeAll;

        // check position
        CookingBehaviour cb = OccupyObj.GetComponent<CookingBehaviour>();
        if (cb != null)
            cb.CheckPosition();
    }

    public GameObject OnTakeOut()
    {
        if (OccupyObj == null)
            return null;

        Rigidbody rb = OccupyObj.GetComponent<Rigidbody>();
        if (rb != null)
            rb.constraints = RigidbodyConstraints.None;

        GameObject tmp = OccupyObj;
        OccupyObj = null;
        return tmp;
    }
}
