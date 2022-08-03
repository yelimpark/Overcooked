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
            Slot slot = occupyObj.GetComponent<Slot>();
            if (slot != null)
                return slot.AbleToPlace(go);
            else
                return false;
        }

        return base.AbleToPlace(go);
    }

    public override void OnPlace(GameObject go)
    {
        if (occupyObj != null)
        {
            Slot slot = occupyObj.GetComponent<Slot>();
            if (slot != null)
                slot.OnPlace(go);
        }
        else
        {
            base.OnPlace(go);
        }
    }

    public override bool AbleToTakeOut()
    {
        //if (occupyObj != null)
        //{
        //    Cookware cookware = occupyObj.GetComponent<Cookware>();
        //    if (cookware != null && cookware.AbleToTakeOut(dest))
        //        return true;
        //}

        return base.AbleToTakeOut();
    }

    public override GameObject OnTakeOut()
    {
        //Cookware cookware = occupyObj.GetComponent<Cookware>();
        //if (cookware != null && cookware.AbleToTakeOut(dest))
        //    return cookware.OnTakeOut(dest);

        return base.OnTakeOut();
    }
}
