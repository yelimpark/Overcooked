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

    public override void OnPlace(GameObject go)
    {
        if (occupyObj != null)
        {
            Cookware cookware = occupyObj.GetComponent<Cookware>();
            if (cookware != null)
                cookware.OnPlace(go);
        }
        else
        {
            base.OnPlace(go);
        }
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

        return base.OnTakeOut(dest);
    }
}
