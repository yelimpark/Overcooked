using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : Slot
{
    public override void OnPlace(GameObject go)
    {
        if (go.CompareTag("Ingrediant") || go.CompareTag("Cookware"))
        {
            base.OnPlace(go);
        }
    }

}