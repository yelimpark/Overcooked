using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithIngrediant : Interact
{
    public override GameObject Cursor
    {
        get { return cursor; }
        set
        {
            Interactable il;

            if (cursor != null)
            {
                il = cursor.GetComponent<Interactable>();
                if (il != null)
                    il.Active = false;
            }

            cursor = value;

            if (cursor != null)
            {
                il = cursor.GetComponent<Interactable>();
                if (il != null)
                    il.Active = true;
            }
        }
    }

    public void Start()
    {
        InteracableTag = "Ingrediant";
    }
}
