using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingBehaviour : MonoBehaviour
{
    private RayInterection rayInterection;
    private string position;
    private bool atPosition = false;

    private string ingrediantName;
    private string next;

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
