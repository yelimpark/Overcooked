using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePlay : MonoBehaviour
{
    public InputHandler ih;

    private void Start()
    {
        ih = GetComponent<InputHandler>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ih.enabled = !ih.enabled;

        }
    }
}
