using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public GameObject occupyObj;

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

        Utils.FixPosition(occupyObj);

        Vector3 newPos = transform.position;
        newPos.y += transform.lossyScale.y * 0.5f + occupyObj.transform.lossyScale.y * 0.5f;
        occupyObj.transform.position = newPos;

        occupyObj.transform.SetParent(transform);
    }

    public virtual bool AbleToTakeOut(GameObject dest)
    {
        if (dest != null)
        {
            Slot slot = dest.GetComponent<Slot>();
            if (slot != null)
                return slot.AbleToPlace(occupyObj);
        }

        return occupyObj != null;
    }

    public virtual GameObject OnTakeOut(GameObject dest)
    {
        GameObject takeout = occupyObj;
        occupyObj = null;

        Utils.UnFixPosition(takeout);

        takeout.transform.parent = null;

        return takeout;
    }
}
