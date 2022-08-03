using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frypan : Cookware
{
    public override void Start()
    {
        type = CoockwareType.FRYPAN;
        base.Start();
    }

    public override GameObject OnTakeOut()
    {
        timebar.pause = true;

        return base.OnTakeOut();
    }
}
