using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSystem : MonoBehaviour
{
    GameObject equipment;
    public GameObject Equipment { get { return equipment; } }

    public Transform hands;

    public void Equip(GameObject go)
    {
        if (equipment != null)
            return;

        equipment = go;

        Rigidbody rb = equipment.GetComponent<Rigidbody>();
        if (rb != null)
            rb.constraints = RigidbodyConstraints.FreezeAll;

        equipment.transform.position = hands.position;
        equipment.transform.SetParent(hands);
    }

    public GameObject Unequip()
    {
        if (equipment == null)
            return null;

        GameObject discard = equipment;
        equipment = null;

        Rigidbody rb = discard.GetComponent<Rigidbody>();
        if (rb != null)
            rb.constraints = RigidbodyConstraints.None;

        discard.transform.parent = null;

        return discard;
    }
}
