using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    private MeshRenderer mr;

    public Shader highlight;
    private Shader standard;

    public void Start()
    {
        mr = GetComponent<MeshRenderer>();
        standard = mr.material.shader;
    }

    public void TurnOn()
    {
        mr.material.shader = highlight;
    }

    public void TurnOff()
    {
        mr.material.shader = standard;
    }
}
