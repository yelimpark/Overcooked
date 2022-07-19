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
    public List<FireCreate> self = new List<FireCreate>();

    public GameObject firePrefab;
    public float time = 0f;

    private ESelfState eSelfState;

    private void Start()
    {
        eSelfState = ESelfState.Self;
        firePrefab.SetActive(false);
    }


    public void Update()
    {
        for(int i = 0; i < self.Count; i++)
        {

        }
        switch(eSelfState)
        {
            case ESelfState.Self:
                
                break;
            case ESelfState.FireSelf:
                // 시간 
                time += Time.deltaTime;                
                // 
                break;
        }
    }

    public void FireOn()
    {
        // 불 이펙트 on, 상태 FireSelf
        if(time < 2f)
        {
            time = 0f;
            firePrefab.SetActive(true);

            
        }
        


    }

    public void FireOff()
    {
        // 불 이펙트 off, 상태 Self
        firePrefab.SetActive(false);
    }
}
