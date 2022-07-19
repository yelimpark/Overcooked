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
                // �ð� 
                // 
                break;
        }
    }

    public void FireOn()
    {
        // �� ����Ʈ on, ���� FireSelf
    }

    public void FireOff()
    {
        // �� ����Ʈ off, ���� Self
    }
}
