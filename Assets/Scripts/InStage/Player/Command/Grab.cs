using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : Command
{
    GameObject player;

    public Grab (GameObject go)
    {
        player = go;
    }

    public override void Execute()
    {
        InteractWithLocation iwl = player.GetComponent<InteractWithLocation>();
        if (iwl != null && iwl.Cursor != null)
        {
            Interactable interactable = iwl.Cursor.GetComponent<Interactable>();
            EquipmentSystem equipmentSystem = player.GetComponent<EquipmentSystem>();
            interactable.OnTakeOutBtnDown(equipmentSystem);
            return;
        }

        InteractWithEquipment iwe = player.GetComponent<InteractWithEquipment>();
        if (iwe != null && iwe.Cursor != null)
        {
            Interactable interactable = iwe.Cursor.GetComponent<Interactable>();
            EquipmentSystem equipmentSystem = player.GetComponent<EquipmentSystem>();
            interactable.OnTakeOutBtnDown(equipmentSystem);
        }
    }

    public override void Execute(float value)
    {
    }

    public override void Execute(bool value)
    {
    }
}
