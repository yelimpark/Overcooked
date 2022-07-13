using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Action
{
    None = 0,
    Chop = 1,
    Cook = 2,
    Combine = 4,
}

public class Ingrediant : MonoBehaviour
{
    public Action action;
    public string ingrediantName;
    public string next;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
