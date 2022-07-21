using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Highlight", fileName = "Highlight.asset")]
public class Highlight : ScriptableObject
{
    public Shader highlight;
    public Shader standard;

    public void TurnOn(GameObject go)
    {
        MeshRenderer mr = go.GetComponentInChildren<MeshRenderer>();
        if (mr != null)
            mr.material.shader = highlight;
    }

    public void TurnOff(GameObject go)
    {
        MeshRenderer mr = go.GetComponentInChildren<MeshRenderer>();
        if (mr != null)
            mr.material.shader = standard;
    }
}
