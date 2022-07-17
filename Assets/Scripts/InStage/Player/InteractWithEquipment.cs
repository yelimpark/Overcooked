using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithEquipment : Interact
{
    public override void OnTriggerEnter(Collider other)
    {
        if (!(other.CompareTag("Ingrediant") || other.CompareTag("Cookware")))
            return;

        base.OnTriggerEnter(other);
    }

    public override void OnTriggerExit(Collider other)
    {
        if (!(other.CompareTag("Ingrediant") || other.CompareTag("Cookware")))
            return;

        base.OnTriggerExit(other);
    }
}
