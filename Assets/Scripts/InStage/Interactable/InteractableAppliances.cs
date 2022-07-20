using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableAppliances : Interactable
{
    public Slot slot;

    public override GameObject TakeOut(GameObject dest)
    {
        if (!slot.AbleToTakeOut(dest))
            return null;

        return slot.OnTakeOut(dest);
    }
}
