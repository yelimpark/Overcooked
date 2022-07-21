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
        if (dest != null)
        {
            Cookware cookware = dest.GetComponent<Cookware>();
            if (cookware != null && cookware.mask == AppliancesType.PLATE)
                return cookware.AbleToTakeOut(dest);
        }

        return base.AbleToTakeOut(dest);
    }

    public override GameObject OnTakeOut(GameObject dest)
    {
        if (dest != null)
        {
            Cookware cookware = dest.GetComponent<Cookware>();
            if (cookware != null && cookware.mask == AppliancesType.PLATE)
                return cookware.OnTakeOut(dest);
        }

        return base.OnTakeOut(dest);
    }
}
