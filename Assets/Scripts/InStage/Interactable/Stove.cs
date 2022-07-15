using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove: Shelf
{
    public override void OnPlace(GameObject go)
    {
        base.OnPlace(go);

        if (go.Equals(OccupyObj))
        {
            CookingBehaivourWithTimer cbwt = OccupyObj.GetComponent<CookingBehaivourWithTimer>();
            if (cbwt != null)
                cbwt.AtPosition();
        }
    }

    public override GameObject OnTakeOut()
    {
        GameObject takeout = base.OnTakeOut();
        if (takeout != null)
        {
            CookingBehaivourWithTimer cbwt = takeout.GetComponent<CookingBehaivourWithTimer>();
            if (cbwt != null)
                cbwt.ExitPosition();
        }
        return takeout;
    }
}
