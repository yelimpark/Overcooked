using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Highlight highlight;

    protected bool active = false;
    public bool Active
    {
        get { return active; }
        set
        {
            active = value;
            if (active)
            {
                highlight.TurnOn(gameObject);
                for (int i = 0; i < transform.childCount; i++)
                {
                    highlight.TurnOn(transform.GetChild(i).gameObject);
                }
            }
            else
            {
                highlight.TurnOff(gameObject);
                for (int i = 0; i < transform.childCount; i++)
                {
                    highlight.TurnOff(transform.GetChild(i).gameObject);
                }
            }
        }
    }

    public virtual bool OnGrab(EquipmentSystem es)
    {
        if (es.Equipment != null)
            return false;

        es.Equip(gameObject);

        return true;
    }
}
