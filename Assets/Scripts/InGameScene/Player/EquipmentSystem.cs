using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSystem : MonoBehaviour
{
    bool equipable = true;
    public float equipErrorRange = 0.1f;

    public Hands hands;
    private GameObject unequipingObj;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Equip(GameObject go)
    {
        if (go == null || !equipable)
            return;

        if (hands.AbleToPlace(go))
            hands.OnPlace(go);

        int layer = LayerMask.NameToLayer("ExceptPlayer");
        go.layer = layer;

        animator.SetBool("isPickUp", true);
    }

    private void Update()
    {
        if (!equipable && Utils.IsFalling(unequipingObj, equipErrorRange))
            UnequipEnd();
    }

    public void UnequipEnd()
    {
        equipable = true;
        int layer = LayerMask.NameToLayer("Default");
        unequipingObj.layer = layer;
        unequipingObj = null;
    }

    public GameObject Unequip()
    {
        if (!hands.AbleToTakeOut(null)|| !equipable)
            return null;

        equipable = false;
        unequipingObj = hands.OnTakeOut(null);
        animator.SetBool("isPickUp", false);

        return unequipingObj;
    }
}