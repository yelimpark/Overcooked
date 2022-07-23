using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AppliancesType
{
    None,
    FRYPAN,
    CUTTING_BOARD,
    PLATE
}

public class Appliances : Slot
{
    public AppliancesType mask;

    public virtual void OnTriggerEnter(Collider other)
    {
        if (AbleToPlace(other.gameObject))
            OnPlace(other.gameObject);
    }

    public override bool AbleToPlace(GameObject go)
    {
        if (occupyObj != null)
        {
            Cookware cookware = occupyObj.GetComponent<Cookware>();
            if (cookware != null)
                return cookware.AbleToPlace(go);
        }

        return base.AbleToPlace(go);
    }

    public override void OnPlace(GameObject go)
    {
        if (occupyObj != null)
        {
            Cookware cookware = occupyObj.GetComponent<Cookware>();
            if (cookware != null)
            {
                cookware.OnPlace(go);
                return;
            }
        }

        base.OnPlace(go);

        CookingBehaviour cb = occupyObj.GetComponent<CookingBehaviour>();
        if (cb != null)
            cb.CurPosition = mask;
    }

    public override bool AbleToTakeOut(GameObject dest)
    {
        if (occupyObj != null)
        {
            Cookware cookware = occupyObj.GetComponent<Cookware>();
            if (cookware != null && cookware.AbleToTakeOut(dest))
                return true;
        }

        return base.AbleToTakeOut(dest);
    }

    public override GameObject OnTakeOut(GameObject dest)
    {
        Cookware cookware = occupyObj.GetComponent<Cookware>();
        if (cookware != null && cookware.AbleToTakeOut(dest))
            return cookware.OnTakeOut(dest);

        CookingBehaviour cb = occupyObj.GetComponent<CookingBehaviour>();
        if (cb != null)
            cb.CurPosition = AppliancesType.None;

        return base.OnTakeOut(dest);
    }
}
