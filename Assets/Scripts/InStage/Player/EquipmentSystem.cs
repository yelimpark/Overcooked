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

    [SerializeField]
    GameObject equipment;
    public GameObject Equipment { get { return equipment; } }

    public Transform hands;

    private State curState = State.NONE;
    public float equipSpeed = 2f;
    public float equipErrorRange = 0.1f;

    private Animator animator;

    public GameObject EquipableTo()
    {
        if (equipment != null)
        {
            Cookware cookware = equipment.GetComponent<Cookware>();
            if (cookware != null && cookware.AbleToPlace(equipment))
            {
                return equipment;
            }
            return null;
        }
        return gameObject;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public bool Equip(GameObject go)
    {
        if (go == null || curState != State.NONE)
            return false;

        var dest = EquipableTo();
        if (dest == null)
        {
            return false;
        }
        else if (dest == gameObject)
        {
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
            return true;
        }
        else
        {

        }
        return false;
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
                if (Utils.IsFalling(equipment, equipErrorRange, layerMask))
                {
                    curState = State.NONE;
                    equipment = null;
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

        curState = State.UNEQUIPING;
        equipment.transform.parent = null;

        animator.SetBool("isPickUp", false);

        return equipment;
    }
}