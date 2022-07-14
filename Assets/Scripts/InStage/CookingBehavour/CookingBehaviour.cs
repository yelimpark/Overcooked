using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingBehaviour : MonoBehaviour
{
    protected RayInterection rayInterection;
    public string position;
    protected bool atPosition = false;
    public virtual bool AtPosition
    {
        get { return atPosition; }
        set { atPosition = value; }
    }

    public string next;

    public virtual void Start()
    {
        rayInterection = GetComponent<RayInterection>();
    }

    public virtual void Update()
    {
        if (atPosition)
            OnPosition();
    }

    public void CheckPosition()
    {
        Transform hit = rayInterection.Shoot().transform;
        if (hit != null && hit.tag == position)
        {
            atPosition = true;
        }
    }

    public virtual void OnPosition() { }
}
