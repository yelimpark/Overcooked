using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoard : Cookware
{
    private bool trigger;

    public override void Start()
    {
        type = CoockwareType.CUTTING_BOARD;
        Position = CoockwareType.CUTTING_BOARD;
        base.Start();
    }

    public void Trigger()
    {
        trigger = true;
        Execute();
        trigger = false;
    }

    public override void Execute()
    {
        if (!trigger)
            return;

        base.Execute();
    }
}
