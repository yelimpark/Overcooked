using UnityEngine;

public class InteractWithLocation : Interact
{
    public override void Update()
    {
        base.Update();

        if (Input.GetButtonDown("Fire1"))
        {
            OnUnequipBtnDown();
        }
    }

    public void OnUnequipBtnDown()
    {
        EquipmentSystem es = GetComponent<EquipmentSystem>();

        if (es != null && es.AbletoUnequip())
        {
            if (cursor != null)
            {
                InteractableAppliances il = cursor.GetComponent<InteractableAppliances>();

                //if (il == null || il.slot.occupyObj != null)
                //{
                //    switch(il.slot.occupyObj.tag)
                //    {
                //        case "Ingrediant":
                //            return;
                //        case "Cookware":
                //            if (il.slot.occupyObj.GetComponent<Cookware>().occupyObj != null)
                //                return;
                //            break;
                //        default:
                //            break;
                //    }
                //}

                Cookware cookware = es.Equipment.GetComponent<Cookware>();
                if (cookware != null && cookware.occupyObj != null)
                {
                    if (il != null && il.slot.AbleToPlace(cookware.occupyObj))
                    {
                        il.slot.OnPlace(cookware.OnTakeOut(cursor));
                    }
                }
                else
                {
                    if (il != null && il.slot.AbleToPlace(es.Equipment))
                    {
                        il.slot.OnPlace(es.Unequip());
                    }
                }

                //if (discarded != null)
                //{
                //    switch (il.slot)
                //    {
                //        case Cookware cookware:
                //            cookware.OnPlace(discarded);
                //            break;
                //        case Appliances appliances:
                //            appliances.OnPlace(discarded);
                //            break;
                //        default:
                //            il.slot.OnPlace(discarded);
                //            break;
                //    }
                //}
            }
            else
            {
                es.Unequip();
            }
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Interactable"))
            return;

        base.OnTriggerEnter(other);
    }

    public override void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Interactable"))
            return;

        base.OnTriggerExit(other);
    }
}
