using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : Slot
{
    private void Start()
    {
        AcceptableTag.Add("Ingrediant");
        AcceptableTag.Add("Cookware");
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
}
