using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSystem : MonoBehaviour
{
    GameObject equipment;
    public GameObject Equipment { get { return equipment; } }

    public Transform hands;

    private bool equiping = false;
    public float equipSpeed = 2f;
    public float equipErrorRange = 0.1f;

    public void Equip(GameObject go)
    {
        if (equipment != null)
            return;

        equipment = go;

        Rigidbody rb = equipment.GetComponent<Rigidbody>();
        if (rb != null)
            rb.constraints = RigidbodyConstraints.FreezeAll;

        //equipment.transform.position = hands.position;
        equiping = true;
        equipment.transform.SetParent(hands);
    }

    private void Update()
    {
        if (equiping)
        {
            Vector3 dir = hands.position - equipment.transform.position;
            equipment.transform.position += dir.normalized * Time.deltaTime * equipSpeed;

            if (Vector3.Distance(hands.position, equipment.transform.position) < equipErrorRange)
            {
                equiping = false;
            }
        }
    }

    public GameObject Unequip()
    {
        if (equipment == null || equiping)
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
