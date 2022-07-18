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

    public Animator animator;

    public bool AbleToEauip()
    {
        if (equipment != null || curState != State.NONE)
            return false;
        return true;
    }

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

        curState = State.EQUIPING;
        equipment.transform.SetParent(hands);

        animator.SetBool("isPickUp", true);
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
                int layerMask = (-1) - (1 << LayerMask.NameToLayer("player"));
                if (equipment==null || Utils.IsFalling(equipment, equipErrorRange, layerMask))
                {
                    curState = State.NONE;
                    equipment = null;
                }
                break;

            default:
                break;
        }
    }

    public bool AbletoUnequip()
    {
        if (equipment == null || curState != State.NONE)
            return false;

        return true;
    }

    public GameObject Unequip()
    {
        if (equipment == null || curState != State.NONE)
            return null;

        Utils.UnFixPosition(equipment);

        Collider collider = equipment.GetComponent<Collider>();
        if (collider != null)
            collider.enabled = true;

        curState = State.UNEQUIPING;
        equipment.transform.parent = null;

        animator.SetBool("isPickUp", false);

        return equipment;
    }
}