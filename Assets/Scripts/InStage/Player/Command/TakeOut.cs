using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeOut : Command
{
    EquipmentSystem es;
    GameObject cursor;

    public TakeOut(EquipmentSystem es, GameObject cursor)
    {
        this.es = es;
        this.cursor = cursor;
    }

    public override void Execute()
    {
        if (cursor == null)
            return;

        var dest = es.EquipableTo();
        Interactable interactable = cursor.GetComponent<Interactable>();
        if (interactable != null)
        {
            var takeOut = interactable.TakeOut(dest);
            es.Equip(takeOut);
        }
    }
}
