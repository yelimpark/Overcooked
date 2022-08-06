using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appliances : Slot
{
    public CoockwareType mask;

    private void Start()
    {
        AcceptableTag.Add("Ingrediant");
        AcceptableTag.Add("Cookware");
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        // photon is maine

        if (AbleToPlace(other.gameObject))
            OnPlace(other.gameObject);
    }

    public override bool AbleToPlace(GameObject go)
    {
        if (occupyObj != null)
        {
            Slot slot = occupyObj.GetComponent<Slot>();
            if (slot != null)
                return slot.AbleToPlace(go);

            Slot goSlot = go.GetComponent<Slot>();

            if (slot != null && goSlot != null)
                return slot.AbleToPlace(goSlot.OccupyObj);

            if (goSlot != null)
                return goSlot.AbleToPlace(occupyObj);

            return false;
        }

        return base.AbleToPlace(go);
    }

    public override void OnPlace(GameObject go)
    {
        if (occupyObj != null)
        {
            Slot slot = occupyObj.GetComponent<Slot>();
            if (slot != null)
            {
                slot.OnPlace(go);
                return;
            }

            Slot goSlot = go.GetComponent<Slot>();
            if (goSlot != null)
            {
                var takeout = OnTakeOut();
                goSlot.OnPlace(takeout);
                OnPlace(go);
            }
        }
        else
        {
            base.OnPlace(go);

            Cookware cookware = occupyObj.GetComponent<Cookware>();
            if (cookware != null)
                cookware.Position = mask;
        }
    }

    public override bool AbleToTakeOut()
    {
        //if (occupyObj != null)
        //{
        //    Cookware cookware = occupyObj.GetComponent<Cookware>();
        //    if (cookware != null && cookware.AbleToTakeOut(dest))
        //        return true;
        //}

        return base.AbleToTakeOut();
    }

    public override GameObject OnTakeOut()
    {
        Cookware cookware = occupyObj.GetComponent<Cookware>();
        //if (cookware != null && cookware.AbleToTakeOut(dest))
        //    return cookware.OnTakeOut(dest);

        if (cookware != null)  
            cookware.Position = CoockwareType.NONE;

        return base.OnTakeOut();
    }
}
