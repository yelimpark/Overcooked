using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSystem : MonoBehaviour
{
    public enum State
    {
        EQUIPING,
        UNEQUIPING,
        NONE
    }

    GameObject equipment;
    public GameObject Equipment { get { return equipment; } }

    public Transform hands;

    private State curState = State.NONE;
    public float equipSpeed = 2f;
    public float equipErrorRange = 0.1f;

    public void Equip(GameObject go)
    {
        if (equipment != null || curState != State.NONE)
            return;

        equipment = go;

        Utils.FixPosition(go);

        var colliders = go.transform.GetComponentsInChildren<Collider>();
        foreach (var childCollider in colliders)
        {
            childCollider.enabled = false;
        }

        //equipment.transform.position = hands.position;
        curState = State.EQUIPING;
        equipment.transform.SetParent(hands);
    }

    private void Update()
    {
        switch (curState)
        {
            case State.EQUIPING:
                Vector3 dir = hands.position - equipment.transform.position;
                equipment.transform.position += dir.normalized * Time.deltaTime * equipSpeed;

                if (Vector3.Distance(hands.position, equipment.transform.position) < equipErrorRange)
                {
                    curState = State.NONE;
                }
                break;

            case State.UNEQUIPING:
                if (equipment.GetComponent<Rigidbody>().velocity.y < 0.1)
                {
                    curState = State.NONE;
                }
                break;

            default:
                break;
        }
    }

    public GameObject Unequip()
    {
        if (equipment == null || curState != State.NONE)
            return null;

        Utils.UnFixPosition(equipment);

        Collider collider = equipment.GetComponent<Collider>();
        if (collider != null)
            collider.enabled = true;

        equipment.transform.parent = null;

        return equipment;
    }
}