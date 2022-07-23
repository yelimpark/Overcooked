using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookware : Slot
{
    public AppliancesType mask;
    private CookingBehaviour cb;

    public bool onlyAtPlate = false;

    private void Start()
    {
        cb = GetComponent<CookingBehaviour>();
    }

    public override bool AbleToPlace(GameObject go)
    {
        if (go == null)
            return false;

         Ingrediant ingrediant = go.GetComponent<Ingrediant>();
        if (ingrediant == null || ingrediant.mask != mask)
            return false;

        return base.AbleToPlace(go);
    }

    public override void OnPlace(GameObject go)
    {
        base.OnPlace(go);

        Ingrediant ingrediant = go.GetComponent<Ingrediant>();
        if (ingrediant != null && ingrediant.mask == mask && cb != null)
            cb.Execute();
    }

    public override bool AbleToTakeOut(GameObject dest)
    {
        if (cb != null && !cb.ExitPosition())
            return false;

        if (dest != null)
        {
            Cookware cookware = dest.GetComponent<Cookware>();
            if (cookware == null || cookware.AbleToPlace(occupyObj))
                return true;
        }

        return false;
    }

    public override GameObject OnTakeOut(GameObject dest)
    {
        return base.OnTakeOut(dest);
    }
}
