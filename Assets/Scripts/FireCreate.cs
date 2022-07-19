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
                break;
            case ESelfState.FireSelf:
                // 시간 
                // 
                break;
        }
    }

    public void FireOn()
    {
        // 불 이펙트 on, 상태 FireSelf
    }

    public void FireOff()
    {
        // 불 이펙트 off, 상태 Self
    }
}
