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

    public Hands hands;

    //[SerializeField]
    //GameObject equipment;
    //public GameObject Equipment {
    //    get {
    //        if 
    //        return equipment; 
    //    } 
    //}

    private GameObject tempGO;

    private State curState = State.NONE;
    public float equipSpeed = 2f;
    public float equipErrorRange = 0.1f;

    private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Equip(GameObject go)
    {
        if (go == null || curState != State.NONE)
            return;

        if (hands.occupyObj == null)
        {
            //equipment = go;

            //Utils.FixPosition(go);

            hands.OnPlace(go);

            int layer = LayerMask.NameToLayer("ExceptPlayer");
            go.layer = layer;

            curState = State.NONE;
            //equipment.transform.SetParent(hands);
            animator.SetBool("isPickUp", true);
        }
        else
        {
            //Cookware cookware = equipment.GetComponent<Cookware>();
            //if (cookware != null && cookware.AbleToPlace(go))
            //{
            //    cookware.OnPlace(go);
            //}
        }
    }

    private void Update()
    {
        switch (curState)
        {
            case State.EQUIPING:
                //Vector3 dir = hands.position - equipment.transform.position;
                //equipment.transform.position += dir.normalized * Time.deltaTime * equipSpeed;

                //if (Vector3.Distance(hands.position, equipment.transform.position) < equipErrorRange)
                //{
                //    curState = State.NONE;
                //}
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
        if (!hands.AbleToTakeOut(null)|| curState != State.NONE)
            return null;

        //Utils.UnFixPosition(equipment);

        curState = State.UNEQUIPING;
        //equipment.transform.parent = null;

        tempGO = hands.OnTakeOut(null);
        //equipment = null;

        animator.SetBool("isPickUp", false);

        return tempGO;
    }
}