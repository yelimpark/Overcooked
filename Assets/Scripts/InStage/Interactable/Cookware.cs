using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookware : Slot
{
    public SlotMask mask;

    public override void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Ingrediant"))
            return;
        OnPlace(other.gameObject);
    }

    public new void OnPlace(GameObject go)
    {
        Ingrediant ingrediant = go.GetComponent<Ingrediant>();
        if (ingrediant == null || ingrediant.mask != mask)
            return;

        base.OnPlace(go);

        CookingBehaviour cb = GetComponent<CookingBehaviour>();
        if (cb != null)
            cb.Execute();
    }

    public override GameObject OnTakeOut()
    {
        if (occupyObj != null)
        {
            CookingBehaviour cb = GetComponent<CookingBehaviour>();
            if (cb == null || !cb.ExitPosition())
                return null;
        }

        return base.OnTakeOut();
    }
}
