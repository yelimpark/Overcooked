using UnityEngine;

public class InteractWithLocation : Interact
{
    public override GameObject Cursor
    {
        get { return cursor; }
        set
        {
            InteractableLocation il;

            if (cursor != null)
            {
                il = cursor.GetComponent<InteractableLocation>();
                if (il != null)
                    il.Active = false;
            }

            cursor = value;

            if (cursor != null)
            {
                il = cursor.GetComponent<InteractableLocation>();
                if (il != null)
                    il.Active = true;
            }
        }
    }

    public void Start()
    {
        InteracableTag = "Interactable";
    }

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

        if (es != null && es.Equipment != null)
        {
            if (cursor != null)
            {
                InteractableLocation il = cursor.GetComponent<InteractableLocation>();

                if (il == null || il.slot.OccupyObj != null)
                    return;

                GameObject discarded = es.Unequip();
                if (discarded != null)
                    il.slot.OnPlace(discarded);
            }
            else
            {
                es.Unequip();
            }
        }
    }
}
