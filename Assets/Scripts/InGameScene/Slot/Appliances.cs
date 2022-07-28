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

        if (occupyObj != null)
        {
            CookingBehaviour cb = occupyObj.GetComponent<CookingBehaviour>();
            if (cb != null)
                cb.CurPosition = mask;
        }
    }

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
            cb.CurPosition = CoockwareType.NONE;

        return base.OnTakeOut(dest);
    }
}
