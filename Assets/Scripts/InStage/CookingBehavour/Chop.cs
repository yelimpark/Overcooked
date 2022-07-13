using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chop : CookingBehaivourWithTimer
{
    public override void Update()
    {
        if (atPosition)
            OnPosition();
    }
}
