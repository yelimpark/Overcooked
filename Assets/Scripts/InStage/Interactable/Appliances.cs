using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appliances : Slot
{
    public SlotMask mask;

    public override void OnTriggerEnter(Collider other)
    {
        if (!(other.CompareTag("Ingrediant") || other.CompareTag("Cookware")))
            return;
        OnPlace(other.gameObject);
    }

    public new void OnPlace(GameObject go)
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

        if (go.Equals(occupyObj))
        {
            CookingBehaviour cb = occupyObj.GetComponent<CookingBehaviour>();
            if (cb != null)
                cb.CurPosition = mask;
        }
    }

    public override GameObject OnTakeOut()
    {
        if (occupyObj != null)
        {
            CookingBehaviour cb = occupyObj.GetComponent<CookingBehaviour>();
            if (cb != null && !cb.ExitPosition())
                return null;
        }

        return base.OnTakeOut();
    }
}
