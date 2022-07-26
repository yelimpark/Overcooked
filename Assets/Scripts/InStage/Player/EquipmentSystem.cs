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

    private GameObject tempGO;

    public Transform hands;

    private State curState = State.NONE;
    public float equipSpeed = 2f;
    public float equipErrorRange = 0.1f;

    private Animator animator;

    //public GameObject GetDestination()
    //{
    //    if (equipment != null)
    //    {
    //        Cookware cookware = equipment.GetComponent<Cookware>();

    //        if (cookware != null)
    //            return equipment;
    //        else 
    //            return null;
    //    }
    //    return gameObject;
    //}

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Equip(GameObject go)
    {
        if (go == null || curState != State.NONE)
            return;

        if (equipment == null)
        {
            equipment = go;

            Utils.FixPosition(go);

            int layer = LayerMask.NameToLayer("ExceptPlayer");
            go.layer = layer;

            curState = State.EQUIPING;
            equipment.transform.SetParent(hands);
            animator.SetBool("isPickUp", true);
        }
        else
        {
            Cookware cookware = equipment.GetComponent<Cookware>();
            if (cookware != null && cookware.AbleToPlace(go))
            {
                cookware.OnPlace(go);
            }
        }
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
                if (Utils.IsFalling(tempGO, equipErrorRange))
                {
                    UnequipEnd();
                }
                break;

            default:
                break;
        }
    }

    public void UnequipEnd()
    {
        curState = State.NONE;
        int layer = LayerMask.NameToLayer("Default");
        tempGO.layer = layer;
        tempGO = null;
    }

    public GameObject Unequip()
    {
        if (equipment == null || curState != State.NONE)
            return null;

        Utils.UnFixPosition(equipment);

        curState = State.UNEQUIPING;
        equipment.transform.parent = null;

        tempGO = equipment;
        equipment = null;

        animator.SetBool("isPickUp", false);

        return tempGO;
    }
}