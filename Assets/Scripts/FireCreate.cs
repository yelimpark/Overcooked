using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ESelfState
{
    Self,
    FireSelf,    
}

public class FireCreate : MonoBehaviour
{
    public List<GameObject> fire = new List<GameObject>();

    public GameObject firePrefab;

    private ESelfState eSelfState;

    private void Start()
    {
        eSelfState = ESelfState.Self;
    }


    public void Update()
    {
        switch(eSelfState)
        {
            case ESelfState.Self:
                Fire();
                break;
            case ESelfState.FireSelf:

                break;
        }
    }
    public void Fire()
    {
        
    }

}
