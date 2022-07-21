using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ESelfState
{
    Self,
    FireSelf,    
}

public class CreateSelf : MonoBehaviour
{
    public List<CreateSelf> self = new List<CreateSelf>();

    public GameObject firePrefab;
    public float time = 0f;

    private bool isFire = false;
    private FireHp firehp;

    private ESelfState eSelfState;

    public ESelfState CurrentSelfState
    {
        get { return eSelfState; }
        set
        {
            eSelfState = value;
            switch(eSelfState)
            {
                case ESelfState.Self:
                    isFire = false;
                    break;
                case ESelfState.FireSelf:
                    // 시간 
                    time = 0f;
                    
                    for (int i = 0; i < self.Count; i++)
                    {
                        
                    }
                    break;
            }
        }
    }

    private void Start()
    {
        eSelfState = ESelfState.Self;
        firePrefab.SetActive(false);
    }


    public void Update()
    {        
        switch(eSelfState)
        {
            case ESelfState.Self:
                FireOff();
                break;
            case ESelfState.FireSelf:
                FireOn();
                break;
        }
    }
    public void FireOn()
    {
        time += Time.deltaTime;
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
