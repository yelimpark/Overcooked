using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    private GameObject OccupyObj;

    public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Ingrediant") || OccupyObj != null)
            return;

        OccupyObj = other.gameObject;

        // position correction
        Rigidbody rb = OccupyObj.GetComponent<Rigidbody>();
        if (rb != null)
            rb.constraints = RigidbodyConstraints.FreezeAll;

        Vector3 newPos = transform.position;
        newPos.y += transform.localScale.y;
        OccupyObj.transform.position = newPos;
        OccupyObj.transform.rotation = Quaternion.identity;

        // check position
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

        Rigidbody rb = takeout.GetComponent<Rigidbody>();
        if (rb != null)
            rb.constraints = RigidbodyConstraints.None;

        return takeout;
    }
}