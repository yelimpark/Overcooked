using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KeyCode = System.String;

public class InteractableCreate : Interactable, ITakeOut
{
    public KeyCode key;
    public ObjectPoolManager poolManager;

    public bool TakeOut(EquipmentSystem es)
    {
        if (key == null)
            return false;

        var go = poolManager.Extract(key);
        es.Equip(go.gameObject);
        return true;
    }
}
