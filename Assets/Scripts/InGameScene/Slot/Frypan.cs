using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frypan : Slot
{
    private CookingBehaviour cb;

    private void Start()
    {
        cb = GetComponent<CookingBehaviour>();
        AcceptableTag.Add("Ingrediant");
    }

    public override bool AbleToPlace(GameObject go)
    {
        if (!base.AbleToPlace(go))
            return false;

        Ingrediant ingrediant = go.GetComponent<Ingrediant>();
        if (ingrediant == null || ingrediant.type != CoockwareType.FRYPAN)
            return false;

        if (occupyObj != null)
            return false;

        return true;
    }

    public override void OnPlace(GameObject go)
    {
        base.OnPlace(go);
        cb.Execute();
    }

    public override bool AbleToTakeOut(GameObject dest)
    {
        if (cb != null && !cb.ExitPosition())
            return false;

        if (dest == null)
            return false;

        Slot slot = dest.GetComponent<Slot>();
        return slot != null && slot.AbleToPlace(occupyObj);
    }
}
