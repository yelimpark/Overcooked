using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    protected GameObject occupyObj;
    public GameObject OccupyObj
    {
        get { return occupyObj; }
    }

    protected List<string> AcceptableTag = new List<string>();

    public virtual bool AbleToPlace(GameObject go)
    {
        if (go == null)
            return false;

        if (!AcceptableTag.Contains(go.tag))
            return false;

        return true;
    }

    public virtual void OnPlace(GameObject go)
    {
        occupyObj = go;

        Rigidbody rb = occupyObj.GetComponent<Rigidbody>();
        if (rb != null)
            rb.isKinematic = true;

        var colliders = occupyObj.GetComponents<Collider>();
        foreach (Collider collider in colliders)
        {
            collider.enabled = false;
        }

        occupyObj.transform.rotation = Quaternion.identity;

        Vector3 newPos = transform.position;
        newPos.y += transform.lossyScale.y * 0.5f + occupyObj.transform.lossyScale.y * 0.5f;
        occupyObj.transform.position = newPos;

        occupyObj.transform.SetParent(transform);
    }

    public virtual bool AbleToTakeOut()
    {
        return occupyObj != null;
    }

    public virtual GameObject OnTakeOut()
    {
        GameObject takeout = occupyObj;
        occupyObj = null;

        Rigidbody rb = takeout.GetComponent<Rigidbody>();
        if (rb != null)
            rb.isKinematic = false;

        var colliders = takeout.GetComponents<Collider>();
        foreach (Collider collider in colliders)
        {
            collider.enabled = true;
        }

        takeout.transform.parent = null;

        return takeout;
    }
}
