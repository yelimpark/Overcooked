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
                // �ð� 
                time += Time.deltaTime;                
                // 
                break;
        }
    }

    public void FireOn()
    {
        // �� ����Ʈ on, ���� FireSelf
        if(time < 2f)
        {
            time = 0f;
            firePrefab.SetActive(true);

            
        }
        


    }

    public void FireOff()
    {
        // �� ����Ʈ off, ���� Self
        firePrefab.SetActive(false);
    }
}
