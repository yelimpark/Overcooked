using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisher : MonoBehaviour
{

    private FireInterection fireInterection;
    
    
    private void Awake()
    {
        fireInterection = GetComponent<FireInterection>();
    }


}
