using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Release : Command
{
    EquipmentSystem es;

    public Release(EquipmentSystem es)
    {
        this.es = es;
    }

    public override void Execute()
    {
        es.Unequip();
    }
}
