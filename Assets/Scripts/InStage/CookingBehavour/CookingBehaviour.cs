using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingBehaviour : MonoBehaviour
{
    public string position;
    protected bool atPosition = false;
    public virtual bool AtPosition
    {
        get { return atPosition; }
        set { atPosition = value; }
    }

    public string next;

    public virtual void Update()
    {
        if (atPosition)
            OnPosition();
    }

    public void CheckPosition()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, Vector3.down, out hit, Utils.RAY_MAX_LENGTH);

        if (hit.transform != null && hit.transform.tag == position)
        {
            atPosition = true;
        }
    }

    public virtual void OnPosition() { }
}
